using System;
using FinalTask;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    //должно ли это быть здесь / только здесь?
    public delegate void Result(int sum);

    abstract class CasinoGameBase
    {
        //protected int _bet;
        //protected int _bank;
        //protected int _quantity;

        public event Result OnWin;
        public event Result OnLoose;
        public event Result OnDraw;

        public CasinoGameBase(int[] values)
        {
            FactoryMethod(values);
        }

        public abstract void PlayGame();

        protected void OnWinInvoke(int param) 
        {
            if (OnWin != null)
            {
                OnWin.Invoke(param);
            } 
        }
        protected virtual void OnLooseInvoke(int param)
        {
            if (OnLoose != null)
            {
                OnLoose.Invoke(param);
            }
        }
        protected virtual void OnDrawInvoke(int param)
        {
            if (OnDraw != null)
            {
                OnDraw.Invoke(param);
            }
        }

        protected abstract void FactoryMethod(int[] values);

        public abstract int ResultOutpu(int bank);
    }
}
