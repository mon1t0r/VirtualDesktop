using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop.Interop.Proxy;

namespace WindowsDesktop.Interop.Build22000
{
    internal class ApplicationView : ComWrapperBase<IApplicationView>, IApplicationView
    {
        public ApplicationView(ComInterfaceAssembly assembly, object comObject)
            : base(assembly, comObject)
        {
        }

        public IntPtr GetThumbnailWindow()
            => this.InvokeMethod<IntPtr>();

        public string GetAppUserModelId()
            => this.InvokeMethod<string>() ?? throw new Exception("Failed to get AppUserModelId.");

        public Guid GetVirtualDesktopId()
            => this.InvokeMethod<Guid>();
    }
}
