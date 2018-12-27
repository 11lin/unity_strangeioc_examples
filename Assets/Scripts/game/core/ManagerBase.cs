using System;

namespace com.ztgame.ioc
{
    public class ManagerBase : IManager, IDisposable
    {
        public ManagerBase()
        {
            ManagerCenter.Instance.AddManager(this);
        }
        virtual public string name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        virtual public void Dispose()
        {
            
        }

        virtual public void onFixUpdate()
        {
            
        }

        virtual public void onInit()
        {
            
        }

        virtual public void onUpdate()
        {
            
        }
    }
}