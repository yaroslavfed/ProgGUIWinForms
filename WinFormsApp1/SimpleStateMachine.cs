﻿using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Machine;

namespace WinFormsApp1
{
    public class SimpleStateMachine
    {
        private readonly PassiveStateMachine<EState, EEvent> machine;

        public SimpleStateMachine()
        {
            var builder = new StateMachineDefinitionBuilder<EState, EEvent>();

            builder.In(EState.Line)
                .On(EEvent.ChangeDrawSprite)
                    .Goto(EState.Spline)
                    .Execute(DrawAsSpline)
                .On(EEvent.Draw)
                    .Execute(DrawAsLine);

            builder.In(EState.Spline)
                .On(EEvent.ChangeDrawSprite)
                    .Goto(EState.Line)
                    .Execute(DrawAsLine)
                .On(EEvent.Draw)
                    .Execute(DrawAsSpline);

            builder.WithInitialState(EState.Line);

            var definition = builder
                .Build();

            machine = definition
                .CreatePassiveStateMachine("SimpleStateMachine");

            machine.Start();
        }

        private void DrawAsSpline()
        {
            // TODO: закинуть сюда структуру аналогичную нажатию на кнопку
            MessageBox.Show("DrawAsSpline");

            // комментарий для теста защищенной ветки
        }

        private void DrawAsLine()
        {
            // TODO: закинуть сюда структуру аналогичную нажатию на кнопку
            MessageBox.Show("DrawAsSpline");
        }
    }
}
