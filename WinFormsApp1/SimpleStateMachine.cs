using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Machine;

namespace WinFormsApp1
{
    public enum EEvent
    {
        DrawEvent,
        ChangeDrawSprite
    }

    public enum EContextStates
    {
        DefaultState = 0,
        LineState = 1,
        SplineState = 2
    }

    public partial class Form1
    {
        #region Private

        private PassiveStateMachine<EContextStates, EEvent>? _fsm;

        private EContextStates _currentState = EContextStates.DefaultState;

        private EContextStates _targetState = EContextStates.DefaultState;

        private IReadOnlyList<EContextStates> _clientTargetList = new List<EContextStates>()
        {
            EContextStates.DefaultState,
            EContextStates.LineState,
            EContextStates.SplineState
        };

        private static IReadOnlyDictionary<string, EContextStates> _clientEvents =
            new Dictionary<string, EContextStates>()
            {
                { "Select draw sprite", EContextStates.DefaultState },
                { "DrawAsLine", EContextStates.LineState },
                { "Draw as spline", EContextStates.SplineState }
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
                .Execute(DrawAsLine);

            builder.In(EContextStates.SplineState)
                .On(EEvent.ChangeDrawSprite)
                .If(() => _targetState == EContextStates.DefaultState).Goto(EContextStates.DefaultState)
                .If(() => _targetState == EContextStates.LineState).Goto(EContextStates.LineState)
                .On(EEvent.DrawEvent)
                .Execute(DrawAsSpline);

#if false
            builder.In(EContextStates.DefaultState).ExecuteOnEntry(() =>
            {
                _currentState = EContextStates.DefaultState;
            });

            builder.In(EContextStates.LineState).ExecuteOnEntry(() =>
            {
                _currentState = EContextStates.LineState;
            });

            builder.In(EContextStates.SplineState).ExecuteOnEntry(() =>
            {
                _currentState = EContextStates.SplineState;
            });
#endif

            builder.WithInitialState(EContextStates.DefaultState);

            var definition = builder
                .Build();

            _fsm = definition
                .CreatePassiveStateMachine("SimpleStateMachine");

            _fsm.Start();
        }

        #endregion

        #region Methods

        private void DrawAsLine()
        {
            chart1.DataSource = null;
            chart1.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.DataSource = Data;
        }
        
        private void DrawAsSpline()
        {
            chart1.DataSource = null;
            chart1.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.DataSource = Data;
        }

        private void ErrorDraw()
        {
#if !AutoBinding
            MessageBox.Show(AutoBindingEnabledStatus);
#endif
            DrawAsLine();
        }

        #endregion

        #region Labels

        private const string AutoBindingEnabledStatus = "Auto selected line sprite";

        #endregion
    }
}