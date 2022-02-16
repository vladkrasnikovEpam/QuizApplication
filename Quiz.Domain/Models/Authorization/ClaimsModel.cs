using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Quiz.Domain.Models.Authorization
{
    public class ClaimsModel
    {
        public const string DefaultIssuer = "LOCAL AUTHORITY";
        //
        // Summary:
        //     The default name claim type; System.Security.Claims.ClaimTypes.Name.
        public const string DefaultNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        //
        // Summary:
        //     The default role claim type; System.Security.Claims.ClaimTypes.Role.
        public const string DefaultRoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        //
        // Summary:
        //     Gets the authentication type.
        //
        // Returns:
        //     The authentication type.
        public string AuthenticationType { get; }
        //
        // Summary:
        //     Gets the name of this claims identity.
        //
        // Returns:
        //     The name or null.
        public string Name { get; }
        //
        // Summary:
        //     Gets or sets the label for this claims identity.
        //
        // Returns:
        //     The label.
        public string Label { get; set; }
        //
        // Summary:
        //     Gets a value that indicates whether the identity has been authenticated.
        //
        // Returns:
        //     true if the identity has been authenticated; otherwise, false.
        public bool IsAuthenticated { get; }
        //
        // Summary:
        //     Gets the claims associated with this claims identity.
        //
        // Returns:
        //     The collection of claims associated with this claims identity.
        public IEnumerable<Claim> Claims { get; }
        //
        // Summary:
        //     Gets or sets the token that was used to create this claims identity.
        //
        // Returns:
        //     The bootstrap context.
        public object BootstrapContext { get; set; }
        //
        // Summary:
        //     Gets or sets the identity of the calling party that was granted delegation rights.
        //
        // Returns:
        //     The calling party that was granted delegation rights.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     An attempt to set the property to the current instance occurs.
        public ClaimsIdentity Actor { get; set; }
        //
        // Summary:
        //     Gets the claim type that will be interpreted as a .NET Framework role among the
        //     claims in this claims identity.
        //
        // Returns:
        //     The role claim type.
        public string RoleClaimType { get; }
        //
        // Summary:
        //     Gets the claim type that is used to determine which claims provide the value
        //     for the System.Security.Claims.ClaimsIdentity.Name property of this claims identity.
        //
        // Returns:
        //     The name claim type.
        public string NameClaimType { get; }
        //
        // Summary:
        //     Contains any additional data provided by a derived type. Typically set when calling
        //     System.Security.Claims.ClaimsIdentity.WriteTo(System.IO.BinaryWriter,System.Byte[]).
        //
        // Returns:
        //     A System.Byte array representing the additional serialized data.
        protected virtual byte[] CustomSerializationData { get; }

        //
        // Summary:
        //     Adds a single claim to this claims identity.
        //
        // Parameters:
        //   claim:
        //     The claim to add.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     claim is null.
        
    }
}
