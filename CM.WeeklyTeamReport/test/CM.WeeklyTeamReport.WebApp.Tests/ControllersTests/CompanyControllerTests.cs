using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.WebApp.Controllers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.WebApp.Tests
{
    public class CompanyControllerTests
    {
        [Fact]
        public void ShouldReturnAllCompanies()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.ReadAll())
                .Returns(new List<Company>()
                {
                    new Company(),
                    new Company(),
                });
            var controller = fixture.GetCompanyController();
            var companies = controller.ReadAll();
            companies.Should().NotBeNull();
            companies.Should().HaveCount(2);
            fixture.CompanyRepository.Verify(x => x.ReadAll(), Times.Once);
        }

        [Fact]
        public void ShouldReturnCompanyById()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.Read(48))
                .Returns(new Company());
            var controller = fixture.GetCompanyController();
            var company = controller.Read(48);
            company.Should().NotBeNull();
            fixture.CompanyRepository.Verify(x => x.Read(48), Times.Once);
        }

        [Fact]
        public void ShouldCreateCompany()
        {
            var company = new Company();
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.Create(company))
                .Returns(company);
            var controller = fixture.GetCompanyController();
            company = controller.Create(company);
            company.Should().NotBeNull();
            fixture.CompanyRepository.Verify(x => x.Create(company), Times.Once);
        }

        [Fact]
        public void ShouldUpdateCompany()
        {
            var company = new Company();
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.Update(company))
                .Returns(company);
            var controller = fixture.GetCompanyController();
            company = controller.Update(company);
            company.Should().NotBeNull();
            fixture.CompanyRepository.Verify(x => x.Update(company), Times.Once);
        }

        [Fact]
        public void ShouldDeleteCompany()
        {
            var fixture = new CompanyControllerFixture();
            fixture.CompanyRepository
                .Setup(x => x.Delete(56));
            var controller = fixture.GetCompanyController();
            controller.Delete(56);
            fixture.CompanyRepository.Verify(x => x.Delete(56), Times.Once);
        }
    }

    public class CompanyControllerFixture
    {
        public Mock<IRepository<Company>> CompanyRepository { get; set; }
        public CompanyControllerFixture()
        {
            CompanyRepository = new Mock<IRepository<Company>>();
        }

        public CompanyController GetCompanyController()
        {
            return new CompanyController(CompanyRepository.Object);
        }
    }
}
