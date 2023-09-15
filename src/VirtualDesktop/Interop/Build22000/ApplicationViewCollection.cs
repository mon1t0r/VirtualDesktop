using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop.Interop.Proxy;

namespace WindowsDesktop.Interop.Build22000
{
    internal class ApplicationViewCollection : ComWrapperBase<IApplicationViewCollection>, IApplicationViewCollection
    {
        public ApplicationViewCollection(ComInterfaceAssembly assembly)
            : base(assembly)
        {
        }

        public ApplicationView GetViewForHwnd(IntPtr hWnd)
        {
            IApplicationView? view = null;

            File.WriteAllText("view.txt", "test");

            this.InvokeMethod<IntPtr>(Args(hWnd, view));
            
            if(view == null)
                throw new ArgumentException("ApplicationView is not found.", nameof(hWnd));

            return new ApplicationView(this.ComInterfaceAssembly, view);
        }

        IApplicationView IApplicationViewCollection.GetViewForHwnd(IntPtr hWnd)
            => this.GetViewForHwnd(hWnd);
    }

}
