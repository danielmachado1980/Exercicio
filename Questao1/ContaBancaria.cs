using System;
using System.Drawing;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        private int NumeroConta { get; set; }
        public string Titular { get; set; }

        private double _saldo;

        public double Saldo
        {
            get { return _saldo; }
        }

        const double TaxaSaque = 3.5;

        public ContaBancaria(int numeroConta, string titular, double saldo)
        {
            NumeroConta = ValidaNumeroConta(numeroConta);
            Titular = titular;
            Deposito(ValidaValor(saldo));
        }

        public ContaBancaria(int numeroConta, string titular)
        {
            NumeroConta = ValidaNumeroConta(numeroConta);
            Titular = titular;
        }

        public void Deposito(double valor)
        {
            _saldo += ValidaValor(valor);
        }

        public void Saque(double valor)
        {
            _saldo -= (ValidaValor(valor) + TaxaSaque);
        }

        private int ValidaNumeroConta(int numero)
        {
            if (numero == 0)
                throw new ArgumentException("O número da conta é inválido");

            return numero;
        }

        private double ValidaValor(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor informado é inválido (somente valores positivos são permitidos)");

            return valor;
        }

        public override string ToString()
        {
            return string.Format("Conta {0}, Titular: {1}, Saldo: $ {2}", NumeroConta, Titular, Saldo.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
