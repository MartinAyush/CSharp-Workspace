namespace ConsoleApp.StriverDsa
{
    public class MinStack
    {
        Stack<int> _minValues;
        Stack<int> _mainStack;
        public MinStack()
        {
            _minValues = new Stack<int>();
            _mainStack = new Stack<int>();
        }

        public void Push(int val)
        {
            _mainStack.Push(val);
            if (_minValues.Count == 0 || val <= _minValues.Peek())
            {
                _minValues.Push(val);
            }
        }

        public void Pop()
        {
            if (_mainStack.Count > 0 && _minValues.Count > 0 && _mainStack.Peek() == _minValues.Peek())
            {
                _minValues.Pop();
            }
            _mainStack.Pop();

        }

        public int Top()
        {
            return _mainStack.Peek();
        }

        public int GetMin()
        {
            return _minValues.Peek();
        }
    }
}