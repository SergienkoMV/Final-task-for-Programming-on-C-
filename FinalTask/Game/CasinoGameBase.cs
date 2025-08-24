using System;
using FinalTask;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    //должно ли это быть здесь / только здесь?
    

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
