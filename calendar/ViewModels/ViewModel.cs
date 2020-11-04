using System;
using System.Collections.Generic;
using System.Text;

namespace calendar.ViewModels
{
    public abstract class ViewModel : ObservableObject
    {
        public virtual void Update()
        {
        }
    }
}
