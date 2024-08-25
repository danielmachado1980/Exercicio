using System.ComponentModel;

namespace Questao5.Domain.Enumerators
{
    public enum TipoErro
    {
        [Description("INVALID_ACCOUNT")]
        INVALID_ACCOUNT,

        [Description("INACTIVE_ACCOUNT")]
        INACTIVE_ACCOUNT,

        [Description("INVALID_VALUE")]
        INVALID_VALUE,

        [Description("INVALID_TYPE")]
        INVALID_TYPE
    }
}
