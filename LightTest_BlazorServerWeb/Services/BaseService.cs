using LightTest_BlazorServerWeb.DataBase;
using LightTest_BlazorServerWeb.DataBase.Models;
using LightTest_BlazorServerWeb.Models;
using LightTest_BlazorServerWeb.Models.Output.Test;
using LightTest_BlazorServerWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LightTest_BlazorServerWeb.Services
{
    public class BaseService : IBaseService
    {
        private readonly AppDbContext _dbContext;
        public BaseService(AppDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public async Task<ResponseService<int>> SaveEntityAsync<Entity>(Entity entity) where Entity : BaseModel
        {
            try
            {
                var dbSet = _dbContext.Set<Entity>();

                if (entity.Id == 0)
                {
                    await dbSet.AddAsync(entity);
                }
                else
                {
                    dbSet.Update(entity);
                }

                await _dbContext.SaveChangesAsync();

                return new()
                {
                    isValid = true,
                    Value = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message
                };
            }
        }
        public async Task<ResponseService<bool>> SaveEntitysAsync<Entity>(List<Entity> entitys, bool isUpdate = false) where Entity : BaseModel
        {
            try
            {
                var dbSet = _dbContext.Set<Entity>();

                if (isUpdate)
                {
                    dbSet.UpdateRange(entitys);
                }
                else
                {
                    await dbSet.AddRangeAsync(entitys);
                }

                await _dbContext.SaveChangesAsync();

                return new()
                {
                    isValid = true,
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseService<TestModel>> GetTestByIdAsync(int id)
        {
            var test = await _dbContext.Tests.Include(x => x.Questions).ThenInclude(x => x.Answers).FirstOrDefaultAsync(x => x.Id == id);

            if (test == null)
            {
                return new();
            }
            TestModel testModel = new()
            {
                Id = test.Id,
                Name = test.Name,
                Description = test.Description
            };
            foreach (var question in test.Questions)
            {
                QuestionModel questionModel = new()
                {
                    Id = question.Id,
                    Name = question.Name,
                    Text = question.Text,
                };
                int countOfCorrectAnswers = 0;
                foreach (var answer in question.Answers)
                {
                    if (answer.isCorrect)
                    {
                        countOfCorrectAnswers++;
                    }
                    AnswerModel answerModel = new()
                    {
                        Id = answer.Id,
                        Text = answer.Text
                    };
                    questionModel.Answers.Add(answerModel);
                }
                if (countOfCorrectAnswers > 1)
                {
                    questionModel.isSeveral = true;
                }
                testModel.Questions.Add(questionModel);
            }

            return new()
            {
                isValid = true,
                Value = testModel
            };
        }
    }

}
