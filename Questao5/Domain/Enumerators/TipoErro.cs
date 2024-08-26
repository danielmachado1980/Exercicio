using System.ComponentModel;

namespace Questao5.Domain.Enumerators
{
    public enum TipoErro
    {
        [Description("Conta inválida")]
        INVALID_ACCOUNT,

        [Description("Conta inativa")]
        INACTIVE_ACCOUNT,

        [Description("Apenas valores positivos são permitidos")]
        INVALID_VALUE,

        [Description("Tipo de operação inválido")]
        INVALID_TYPE,
    }
}
