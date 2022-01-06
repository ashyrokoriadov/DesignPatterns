using Autofac.Features.AttributeFilters;
using System.Collections.Generic;

namespace State.States
{
    public class DefaultOperatorStateCollection : IOperatorStateCollection
    {
        private readonly IEnumerable<IOperatorState> _possibleStates;

        public DefaultOperatorStateCollection(
            [KeyFilter(StateName.FREE)] IOperatorState operatorFreeState,
            [KeyFilter(StateName.BREAK)] IOperatorState operatorBreakState,
            [KeyFilter(StateName.WRAP_UP)] IOperatorState operatorWrapUpState,
            [KeyFilter(StateName.HANDLES_CONVERSATION)] IOperatorState operatorHandlesConversationState,
            [KeyFilter(StateName.LOGOUT)] IOperatorState logOutState)
        {
            _possibleStates = new[] { 
                operatorFreeState, 
                operatorBreakState, 
                operatorWrapUpState, 
                operatorHandlesConversationState,
                logOutState
            };
        }

        public IEnumerable<IOperatorState> AsEnumerable() => _possibleStates;
    }
}
