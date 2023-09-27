// ------------------------------------------------------------------------------
//  SimpleStateMachine.cs
//  Простая итерация конечного автомата для выбора видов отрисовки.
// ------------------------------------------------------------------------------

using System.Windows.Forms.DataVisualization.Charting;
using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Machine;

namespace WinFormsApp1
{
    #region Enums
     
    public enum EEvent
    {
        DrawEvent,
        ChangeDrawSprite
    }

    public enum EContextStates
    {
        DefaultState = 0,
        LineState,
        SplineState
    }

    #endregion

    public partial class Form1
    {
        #region Private fields

        private PassiveStateMachine<EContextStates, EEvent>? _fsm;

        private EContextStates _currentState;
        
        private EContextStates _targetState;

        private static IReadOnlyDictionary<string, (EContextStates contextState, SeriesChartType chartType)> _clientEvents =
            new Dictionary<string, (EContextStates, SeriesChartType)>()
            {
                { "Select draw sprite", (EContextStates.DefaultState, SeriesChartType.Line) },
                { "Draw as line", (EContextStates.LineState, SeriesChartType.Line) },
                { "Draw as spline", (EContextStates.SplineState, SeriesChartType.Spline) }
            };

        #endregion

        #region Constructors

        private void InitializeFsm()
        {
            var builder = new StateMachineDefinitionBuilder<EContextStates, EEvent>();

            builder.In(EContextStates.DefaultState)
                .On(EEvent.ChangeDrawSprite)
                    .If(() => _targetState == EContextStates.LineState).Goto(EContextStates.LineState)
                    .If(() => _targetState == EContextStates.SplineState).Goto(EContextStates.SplineState)
                .On(EEvent.DrawEvent)
                    .Goto(EContextStates.LineState)
                    .Execute(ErrorDraw);

            builder.In(EContextStates.LineState)
                .On(EEvent.ChangeDrawSprite)
                    .If(() => _targetState == EContextStates.DefaultState).Goto(EContextStates.DefaultState)
                    .If(() => _targetState == EContextStates.SplineState).Goto(EContextStates.SplineState)
                .On(EEvent.DrawEvent)
                    .Execute(Draw);

            builder.In(EContextStates.SplineState)
                .On(EEvent.ChangeDrawSprite)
                    .If(() => _targetState == EContextStates.DefaultState).Goto(EContextStates.DefaultState)
                    .If(() => _targetState == EContextStates.LineState).Goto(EContextStates.LineState)
                .On(EEvent.DrawEvent)
                    .Execute(Draw);
            
            builder.In(EContextStates.DefaultState).ExecuteOnEntry(() =>
            {
                _currentState = EContextStates.DefaultState;
            });
            
            builder.In(EContextStates.LineState).ExecuteOnEntry(() =>
            {
                comboBox1.SelectedIndex = (int)EContextStates.LineState;
                _currentState = EContextStates.LineState;
            });

            builder.In(EContextStates.SplineState).ExecuteOnEntry(() =>
            {
                comboBox1.SelectedIndex = (int)EContextStates.SplineState;
                _currentState = EContextStates.SplineState;
            });
            
            builder.WithInitialState(EContextStates.DefaultState);

            var definition = builder
                .Build();

            _fsm = definition
                .CreatePassiveStateMachine("SimpleStateMachine");

            _fsm.Start();
        }

        #endregion

        #region Methods

        private void Draw()
        {
            var currentChartType = _clientEvents.FirstOrDefault(x => x.Value.contextState == _currentState).Value.chartType;
            DrawGraphics(currentChartType);
        }

        private void ErrorDraw()
        {
#if !AutoBinding
            MessageBox.Show(AutoBindingEnabledStatus);
#endif
            _fsm?.Fire(EEvent.DrawEvent);
            
        }

        #endregion

        #region Labels

        private const string AutoBindingEnabledStatus = "Auto selected LINE sprite";

        #endregion
    }
}