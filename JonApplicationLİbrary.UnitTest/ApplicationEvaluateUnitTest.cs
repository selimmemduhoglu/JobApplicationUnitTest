using JobApplication;
using JobApplication.Models;

namespace JonApplicationLİbrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        // UnitOfWork_Condition_ExpectedResult
        // OR
        // Condition_Result
        // OR
        // UnitOfWork_ExpectedResult_Condition


        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            // Arrange

            var evaulator = new ApplicationEvaluator(null);
            var form = new JobApplicationModel()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                }
            };

            // Action

            ApplicationResult appResult = evaulator.Evaluate(form);

            // Assert


            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }

        [Test]
        public void Application_WithNoTechStack_TransferredToAutoRejected()
        {
            // Arrange

            var evaulator = new ApplicationEvaluator(null);
            var form = new JobApplicationModel()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                },
                TechStackList = new System.Collections.Generic.List<string>() { string.Empty }
            };

            // Action

            ApplicationResult appResult = evaulator.Evaluate(form);

            // Assert


            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);
        }


        [Test]
        public void Application_WithtechStackOver75P_TransferredToAutoAccepted()
        {
            // Arrange

            var evaulator = new ApplicationEvaluator(null);
            var form = new JobApplicationModel()
            {
                Applicant = new Applicant()
                {
                    Age = 19
                },
                TechStackList = new System.Collections.Generic.List<string>()
                {
                  "C#",
                  "RabbitMQ",
                   "MicroService",
                   "VisualStudio",
                },
                YearsOfExperience = 16,

            };

            // Action

            ApplicationResult appResult = evaulator.Evaluate(form);

            // Assert


            Assert.AreEqual(appResult, ApplicationResult.AutoAccepted);
        }

    }
}