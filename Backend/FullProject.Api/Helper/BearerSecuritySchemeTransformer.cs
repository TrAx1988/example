using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace FullProject.Api.Helper
{
    /// <summary>
    /// Transformator für OpenAPI-Dokumente, der das Bearer-Sicherheits-Schema hinzufügt,
    /// wenn das Authentifizierungsschema "Bearer" vorhanden ist.
    /// </summary>
    internal sealed class BearerSecuritySchemeTransformer : IOpenApiDocumentTransformer
    {
        private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;

        /// <summary>
        /// Initialisiert eine neue Instanz des <see cref="BearerSecuritySchemeTransformer"/>.
        /// </summary>
        /// <param name="authenticationSchemeProvider">Provider für Authentifizierungsschemata.</param>
        public BearerSecuritySchemeTransformer(IAuthenticationSchemeProvider authenticationSchemeProvider)
        {
            _authenticationSchemeProvider = authenticationSchemeProvider;
        }

        /// <summary>
        /// Transformiert das OpenAPI-Dokument, indem das Bearer-Sicherheits-Schema hinzugefügt wird,
        /// falls das entsprechende Authentifizierungsschema vorhanden ist.
        /// </summary>
        /// <param name="document">Das zu transformierende OpenAPI-Dokument.</param>
        /// <param name="context">Der Kontext der Transformation.</param>
        /// <param name="cancellationToken">Token zum Abbrechen des Vorgangs.</param>
        /// <returns>Ein Task, der die asynchrone Operation repräsentiert.</returns>
        public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            // Alle verfügbaren Authentifizierungsschemata abrufen
            var authenticationSchemes = await _authenticationSchemeProvider.GetAllSchemesAsync();

            // Prüfen, ob das "Bearer"-Schema vorhanden ist
            if (authenticationSchemes.Any(authScheme => authScheme.Name == "Bearer"))
            {
                // Sicherheitsanforderungen für Bearer definieren
                var requirements = new Dictionary<string, OpenApiSecurityScheme>
                {
                    ["Bearer"] = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        In = ParameterLocation.Header,
                        BearerFormat = "JWT"
                    }
                };

                // Sicherheits-Schema zum Dokument hinzufügen
                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes = requirements;

                // Sicherheitsanforderung zu allen Operationen hinzufügen
                foreach (var operation in document.Paths.Values.SelectMany(path => path.Operations))
                {
                    operation.Value.Security.Add(new OpenApiSecurityRequirement
                    {
                        [new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }] = Array.Empty<string>()
                    });
                }
            }
        }