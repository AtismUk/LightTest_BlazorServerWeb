using LightTest_BlazorServerWeb.DataBase;
using LightTest_BlazorServerWeb.DataBase.Models.Test;
using LightTest_BlazorServerWeb.DataBase.Models.UserPart;
using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.Output.Test;
using LightTest_BlazorServerWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightTest_BlazorServerWeb.Services
{
    public class TestService : ITestService
    {
        private readonly AppDbContext _dbContext;
        private readonly IBaseService _baseService;
        public TestService(AppDbContext appDbContext, IBaseService baseService)
        {
            _dbContext = appDbContext;
            _baseService = baseService;
        }

        public async Task<ResponseService<ResultOfTest>> ConfirmTestAsync(TestModel testModel)
        {
            //// Получаем юзера из кукки
            //var userSession = await _authService.GetUserInfoAsync();
            //if (!userSession.isValid)
            //{
            //    return new()
            //    {
            //        Message = "Ошибка авторизации"
            //    };
            //}


            // Получаем юзера из БД
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == 1);

            if (user == null)
            {
                return new()
                {
                    Message = "Ошибка авторизации"
                };
            }


            // Создаем объект пройденного теста
            TestResultEntity testResult = new()
            {
                userId = user.Id,
                testId = testModel.Id,
            };

            // Создаем объект ответов
            List<AnswerResultEntity> answerResultEntities = new();
            // Получаем все оригинал вопросы из БД
            var questionsEntity = _dbContext.Questions.Include(x => x.Answers).Where(x => x.testId == testModel.Id).ToList();
            foreach (var question in testModel.Questions)
            {
                // берем вопрос, считаем количество правильных в нем ответов и создаем переменную, которая будет считать правильные выбранные ответы
                var questionEntity = questionsEntity.First(x => x.Id == question.Id);
                var countOfCorrect = questionEntity.Answers.Where(x => x.isCorrect).Count();
                var countOfCorrectSelected = 0;
                foreach (var answer in question.Answers)
                {
                    if (answer.isSelected)
                    {
                        if (questionEntity.Answers.First(x => x.Id == answer.Id).isCorrect == true)
                        {
                            countOfCorrectSelected++;
                        }
                        AnswerResultEntity answerResult = new()
                        {
                            answerId = answer.Id,
                            questionId = question.Id,
                        };
                        answerResultEntities.Add(answerResult);
                    }
                }
                // Считаем результат
                if (countOfCorrect == countOfCorrectSelected)
                {
                    testResult.Score += 1;

                }
            }

            // Считаем результат в процентах
            testResult.Score = testResult.Score * 100 / questionsEntity.Count();

            // Сохраняем результат
            var res = await _baseService.SaveEntityAsync<TestResultEntity>(testResult);

            if (!res.isValid)
            {
                return new()
                {
                    Message = "Ошибка сервера"
                };
            }
            foreach (var AnswerResultEntity in answerResultEntities)
            {
                AnswerResultEntity.TestResultId = res.Value;
            }

            // Сохраняем ответы для статистики
            var resAnswers = await _baseService.SaveEntitysAsync<AnswerResultEntity>(answerResultEntities);

            if (!resAnswers.isValid)
            {
                return new()
                {
                    Message = "Ошибка сервера"
                };
            }
            return new()
            {
                isValid = true,
                Value = new()
                {

                }
            };
        }

    }
}
