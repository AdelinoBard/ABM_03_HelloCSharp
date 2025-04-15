using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABM_HelloCSharp.Tests
{
    // Classe de testes para a classe Program
    [TestClass]  // Atributo que marca esta classe como uma classe de teste
    public class ProgramTests
    {
        // Teste para verificar o método CalcularTamanhoNome
        [TestMethod]  // Atributo que marca este método como um caso de teste
        public void CalcularTamanhoNome_DeveRetornarTamanhoCorreto()
        {
            // Arrange (Preparação): 
            // O teste verifica se o método ignora espaços extras e conta apenas caracteres
            
            // Act (Ação): Chama o método com string contendo espaços
            int resultado = Program.CalcularTamanhoNome("  Alice ");
            
            // Assert (Verificação): Verifica se o resultado é o esperado (5 caracteres)
            Assert.AreEqual(5, resultado);
        }

        // Teste para verificar o método SaudacaoPersonalizada
        [TestMethod]
        public void SaudacaoPersonalizada_DeveConterNome()
        {
            // Arrange: Teste verifica se o nome passado aparece na saudação
            
            // Act: Chama o método com um nome específico
            string saudacao = Program.SaudacaoPersonalizada("Lucas");
            
            // Assert: Verifica se a string resultante contém o nome
            Assert.IsTrue(saudacao.Contains("Lucas"));
        }
    }
}