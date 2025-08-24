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
        //protected int _bet;
        //protected int _bank;
        //protected int _quantity;

        public event Result OnWin;
        public event Result OnLoose;
        public event Result OnDraw;

        public CasinoGameBase(int _quantity)
        {
            FactoryMethod(_quantity);
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

        protected abstract void FactoryMethod(int _quantity);

        public abstract void ResultOutpu();
    }
}
