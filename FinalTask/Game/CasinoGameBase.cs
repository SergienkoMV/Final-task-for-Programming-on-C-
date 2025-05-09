using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    abstract class CasinoGameBase
    {
        public CasinoGameBase()
        {
            FactoryMethod();
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

        protected abstract void FactoryMethod();


    }
}
