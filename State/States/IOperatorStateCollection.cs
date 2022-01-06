using System.Collections.Generic;

namespace State.States
{
    public interface IOperatorStateCollection
    {
        IEnumerable<IOperatorState> AsEnumerable();
    }
}
