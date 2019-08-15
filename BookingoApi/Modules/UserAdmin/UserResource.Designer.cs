﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookingoApi.Modules.UserAdmin {
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
    internal class UserResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserResource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BookingoApi.Modules.UserAdmin.UserResource", typeof(UserResource).Assembly);
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
        ///   Busca una cadena traducida similar a The users exists in auth system.
        /// </summary>
        internal static string AuthUserExist {
            get {
                return ResourceManager.GetString("AuthUserExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user has been created.
        /// </summary>
        internal static string Created {
            get {
                return ResourceManager.GetString("Created", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user must have an email.
        /// </summary>
        internal static string EmailRequired {
            get {
                return ResourceManager.GetString("EmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a It was not possible to create the user in the authentication system.
        /// </summary>
        internal static string ErrorAuthCreate {
            get {
                return ResourceManager.GetString("ErrorAuthCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a It was not possible to create the user in the local system.
        /// </summary>
        internal static string ErrorLocalCreate {
            get {
                return ResourceManager.GetString("ErrorLocalCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user exists in the system.
        /// </summary>
        internal static string LocalUserExist {
            get {
                return ResourceManager.GetString("LocalUserExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user must have a full name.
        /// </summary>
        internal static string NameRequired {
            get {
                return ResourceManager.GetString("NameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a An error occurred when creating the user.
        /// </summary>
        internal static string NoCreated {
            get {
                return ResourceManager.GetString("NoCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user is not valid.
        /// </summary>
        internal static string NotValid {
            get {
                return ResourceManager.GetString("NotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user must have a phone number (Example +573005559090).
        /// </summary>
        internal static string PhoneRequired {
            get {
                return ResourceManager.GetString("PhoneRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user must have a role.
        /// </summary>
        internal static string RoleRequired {
            get {
                return ResourceManager.GetString("RoleRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No roles found.
        /// </summary>
        internal static string RolesNotFound {
            get {
                return ResourceManager.GetString("RolesNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a The user must have a Uid.
        /// </summary>
        internal static string UidRequired {
            get {
                return ResourceManager.GetString("UidRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a User updated.
        /// </summary>
        internal static string Updated {
            get {
                return ResourceManager.GetString("Updated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Error when updating.
        /// </summary>
        internal static string UpdateError {
            get {
                return ResourceManager.GetString("UpdateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No users found.
        /// </summary>
        internal static string UsersNotFound {
            get {
                return ResourceManager.GetString("UsersNotFound", resourceCulture);
            }
        }
    }
}
