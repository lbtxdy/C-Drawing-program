
namespace 绘图程序.Properties {
    using System;
    
    
  
    ///   一个强类型的资源类，用于查找本地化的字符串等。
  
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("绘图程序.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
      
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static System.Drawing.Bitmap Circle {
            get {
                object obj = ResourceManager.GetObject("Circle", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
       
        internal static System.Drawing.Bitmap eraser1 {
            get {
                object obj = ResourceManager.GetObject("eraser1", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap FillCircle {
            get {
                object obj = ResourceManager.GetObject("FillCircle", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
       
        internal static System.Drawing.Bitmap Fillrect {
            get {
                object obj = ResourceManager.GetObject("Fillrect", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap line {
            get {
                object obj = ResourceManager.GetObject("line", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static byte[] pb {
            get {
                object obj = ResourceManager.GetObject("pb", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        
        internal static System.Drawing.Bitmap Pencil {
            get {
                object obj = ResourceManager.GetObject("Pencil", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap rect {
            get {
                object obj = ResourceManager.GetObject("rect", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
