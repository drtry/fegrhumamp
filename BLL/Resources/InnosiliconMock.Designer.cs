﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL.Resources {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class InnosiliconMock {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal InnosiliconMock() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BLL.Resources.InnosiliconMock", typeof(InnosiliconMock).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///&quot;jwt&quot;: &quot;eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJBc2ljTWluZXIiLCJpYXQiOjE2NzkyNDAwMDYsImV4cCI6MTY3OTI2MTYwNiwidXNlciI6ImFkbWluIn0.fXwJoRoax14rt8XZw6Y89fixLOomUP-fmcQlwkeqgYI&quot;,
        ///&quot;success&quot;: true
        ///}.
        /// </summary>
        internal static string mockAuth {
            get {
                return ResourceManager.GetString("mockAuth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///    &quot;success&quot;: true,
        ///    &quot;DEVS&quot;: [
        ///        {
        ///            &quot;ASC&quot;: 0,
        ///            &quot;Name&quot;: &quot;DT1&quot;,
        ///            &quot;ID&quot;: 0,
        ///            &quot;Enabled&quot;: &quot;Y&quot;,
        ///            &quot;Status&quot;: &quot;Alive&quot;,
        ///            &quot;Temperature&quot;: 62,
        ///            &quot;MHS av&quot;: 2706206.95,
        ///            &quot;MHS 5s&quot;: 7647214.06,
        ///            &quot;MHS 1m&quot;: 4701833.4,
        ///            &quot;MHS 5m&quot;: 1422247.98,
        ///            &quot;MHS 15m&quot;: 511789.29,
        ///            &quot;Accepted&quot;: 9,
        ///            &quot;Rejected&quot;: 0,
        ///            &quot;Hardware Errors&quot;: 1627,
        ///            &quot;Utility&quot;: 3.05 [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string mockSummary {
            get {
                return ResourceManager.GetString("mockSummary", resourceCulture);
            }
        }
    }
}
