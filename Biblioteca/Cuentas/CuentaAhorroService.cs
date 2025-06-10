using System;

namespace Biblioteca.Cuentas
{
    public class CuentaAhorroService
    {
        public bool PuedeRetirar(bool cuentaActiva, decimal saldo, decimal monto, decimal limiteDiario, bool bloqueadaFraude)
        {
            if (!cuentaActiva) return false;
            if (bloqueadaFraude) return false;
            if (saldo < monto) return false;
            if (monto > limiteDiario) return false;
            if (monto % 10 != 0) return false;
            return true;
        }
    }
}