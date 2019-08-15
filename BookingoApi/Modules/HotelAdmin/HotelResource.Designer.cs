﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingoApi.Modules.HotelAdmin {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class HotelResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal HotelResource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BookingoApi.Modules.HotelAdmin.HotelResource", typeof(HotelResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a The hotel must have a address.
        /// </summary>
        internal static string AddressRequired {
            get {
                return ResourceManager.GetString("AddressRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The hotel must have a city.
        /// </summary>
        internal static string CityRequired {
            get {
                return ResourceManager.GetString("CityRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Hotel deleted.
        /// </summary>
        internal static string Deleted {
            get {
                return ResourceManager.GetString("Deleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a There is already a hotel with the same name and city.
        /// </summary>
        internal static string ExistsHotel {
            get {
                return ResourceManager.GetString("ExistsHotel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The hotel must have a name.
        /// </summary>
        internal static string NameRequired {
            get {
                return ResourceManager.GetString("NameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a There are no hotels in the system..
        /// </summary>
        internal static string NoHotels {
            get {
                return ResourceManager.GetString("NoHotels", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a You must create cities.
        /// </summary>
        internal static string NotCities {
            get {
                return ResourceManager.GetString("NotCities", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Hotel not found.
        /// </summary>
        internal static string NotFound {
            get {
                return ResourceManager.GetString("NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The hotel is not valid.
        /// </summary>
        internal static string NotValid {
            get {
                return ResourceManager.GetString("NotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The hotel must have a stars.
        /// </summary>
        internal static string StarsRequired {
            get {
                return ResourceManager.GetString("StarsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The hotel must have a tax (%).
        /// </summary>
        internal static string TaxRequired {
            get {
                return ResourceManager.GetString("TaxRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Hotel updated.
        /// </summary>
        internal static string Updated {
            get {
                return ResourceManager.GetString("Updated", resourceCulture);
            }
        }
    }
}
