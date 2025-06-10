using NUnit.Framework;
using Biblioteca.Cuentas;

namespace Biblioteca.Tests.Cuentas
{
    public class CuentaAhorroServiceTests
    {
        private CuentaAhorroService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CuentaAhorroService();
        }

        // TC1: Todo válido
        [Test]
        // TC1: Todos los datos válidos, debe permitir el retiro
        public void TC1_TodoValido_DebePermitirRetiro()
        {
            var resultado = _service.PuedeRetirar(true, 500, 100, 200, false);
            Assert.IsTrue(resultado);
        }

        // TC2: Cuenta inactiva
        [Test]
        // TC2: Cuenta inactiva, no debe permitir el retiro
        public void TC2_CuentaInactiva_NoPermiteRetiro()
        {
            var resultado = _service.PuedeRetirar(false, 500, 100, 200, false);
            Assert.IsFalse(resultado);
        }

        // TC3: Saldo insuficiente
        [Test]
        // TC3: Saldo insuficiente, no debe permitir el retiro
        public void TC3_SaldoInsuficiente_NoPermiteRetiro()
        {
            var resultado = _service.PuedeRetirar(true, 50, 100, 200, false);
            Assert.IsFalse(resultado);
        }

        // TC4: Excede límite diario
        [Test]
        // TC4: Monto excede el límite diario, no debe permitir el retiro
        public void TC4_ExcedeLimiteDiario_NoPermiteRetiro()
        {
            var resultado = _service.PuedeRetirar(true, 500, 250, 200, false);
            Assert.IsFalse(resultado);
        }

        // TC5: Cuenta bloqueada por fraude
        [Test]
        // TC5: Cuenta bloqueada por fraude, no debe permitir el retiro
        public void TC5_BloqueadaFraude_NoPermiteRetiro()
        {
            var resultado = _service.PuedeRetirar(true, 500, 100, 200, true);
            Assert.IsFalse(resultado);
        }

        // TC6: Monto no múltiplo de 10
        [Test]
        // TC6: Monto no es múltiplo de 10, no debe permitir el retiro
        public void TC6_MontoNoMultiplo10_NoPermiteRetiro()
        {
            var resultado = _service.PuedeRetirar(true, 500, 105, 200, false);
            Assert.IsFalse(resultado);
        }
    }
}