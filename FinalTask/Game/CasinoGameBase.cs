using System;

namespace FinalTask.Game
{
    abstract class CasinoGameBase
    {
        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        public CasinoGameBase(int[] values)
        {
            FactoryMethod(values);
        }

        public abstract void PlayGame();

        protected virtual void OnWinInvoke() => OnWin?.Invoke();

        protected virtual void OnLooseInvoke() => OnLoose?.Invoke();

        protected virtual void OnDrawInvoke()
        {
            if (OnDraw != null)
            {
                OnDraw.Invoke();
            }
        }

        protected abstract void FactoryMethod(int[] values);

        public abstract void ResultOutpu();
    }
}
