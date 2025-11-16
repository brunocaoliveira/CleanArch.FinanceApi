using System;
using Xunit;
using Moq;
using FinancasPessoais.Api.Dtos;
using FinancasPessoais.Api.Interface; // Para ITransacaoRepository
using FinancasPessoais.Api.Models;    // <-- A LINHA QUE FALTAVA
using FinancasPessoais.Api.Services;   // Para TransacaoService

namespace FinancasPessoais.Api.Tests
{
    public class TransacaoServiceTests
    {
      [Fact]
      public async Task AdicionarAsync_QuandoTransacaoEValida_DeveRetornarTransacaoEValida_DeveRetornarTransacaoCompleta()
      {
        // arrange(preparar)

        // crio a dto de entradad válida, como se fosse algo vindo do postman.
        var dto = new CriarTransacaoDto
        {
            Descricao = "Salário",
            Valor= 5000,
            Tipo= ETipoTransacao.Receita
        };
        //crio um mock (simulador) do repositorio
        var repositoryMock = new Mock<ITransacaoRepository>();

        repositoryMock.Setup(r=> r.SaveChangesAsync())
            .ReturnsAsync(true); //retorna uma task<bool> com valor de true


        //crio um serviço real, mas passando o repositório mockado/fingido para ele

        var service = new TransacaoService(repositoryMock.Object);

        var transacaoCriada = await service.AdicionarAsync(dto); //método que vou testar

        Assert.NotNull(transacaoCriada);   //verifico se a transação criada não é nula
        Assert.Equal("Salário", transacaoCriada.Descricao);  //verifico se a descrição é a mesma do dto
        Assert.Equal(5000, transacaoCriada.Valor);   //verifico se o valor também é o mesmo do dto
        Assert.NotEqual(Guid.Empty, transacaoCriada.Id); // verifico se o serviço gerou um id novo
        Assert.NotEqual(default(DateTime), transacaoCriada.Data);// e verifico se gerou data


      }

      [Fact]
      public async Task AdicionarAsync_QuandoValorEZero_DeveLancarExcecao()
      {
        // Given
        var dtoComValorZero = new CriarTransacaoDto
        {
            Descricao= "Teste de Erro",
            Valor= 0, //valor zerado pra teste
            Tipo= ETipoTransacao.Despesa
        };
            //crio o simulador do repositório
        var repositoryMock = new Mock<ITransacaoRepository>();
        var service = new TransacaoService(repositoryMock.Object);

       await Assert.ThrowsAsync<Exception>(
            () => service.AdicionarAsync(dtoComValorZero)
        );
        
      }
      [Fact]
        public async Task Adicionar_QuandoTransacaoEValida_DeveChamarRepositorio()
            { //arrange (preparar)
                
                var dto= new CriarTransacaoDto{
            
                
                    Descricao = "Compra",
                    Valor = 100,
                    Tipo = ETipoTransacao.Receita
                };
                    var repositoryMock= new Mock<ITransacaoRepository>();

                    repositoryMock.Setup(r=> r.SaveChangesAsync())
                        .ReturnsAsync(true); //configuracao de retorno do mock

                    var service= new TransacaoService(repositoryMock.Object);
                    //act (agir)
                  await  service.AdicionarAsync(dto);

                    //assert seguindo os padrões AAA


                    //Aqui verifiquei se o método Add do repositório foi chamado exatamente uma vez
                    repositoryMock.Verify(r=> r.AddAsync(It.IsAny<Transacao>()), Times.Once);

                    //Também verifiquei se o método SaveChanges também foi chamado.
                    repositoryMock.Verify(r=> r.SaveChangesAsync(), Times.Once);
                }
            }
    }
    
      
        
    

