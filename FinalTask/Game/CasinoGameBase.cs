using System;
using FinalTask;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    abstract class CasinoGameBase
    {
        //protected int _bet;
        //protected int _bank;
        //protected int _quantity;

        public CasinoGameBase(int _quantity)
        {
            FactoryMethod(_quantity);
        }

        public abstract void PlayGame();

        protected void OnWinInvoke() 
        {
            //вызывает событие OnWin (создеть в этом классе)
        }
        protected void OnLooseInvoke()
        {
            //вызывает событие OnLoose (создеть в этом классе)
        }
        protected void OnDrawInvoke()
        {
            //вызывает событие OnDraw (создеть в этом классе)
        }

        protected abstract void FactoryMethod(int _quantity);



        public abstract void ResultOutpu();
    }
}
