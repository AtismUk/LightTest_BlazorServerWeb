namespace LightTest_BlazorServerWeb
{
    public static class Mapper
    {
        public static ToModel MapperModel<FromModel, ToModel>(FromModel fromModel) where ToModel : class, new()
        {
            Type fromModelType = fromModel!.GetType();
            Type ToModelType = new ToModel().GetType();

            ToModel dbModel = new();

            foreach (var propertyFromModel in fromModelType.GetProperties())
            {
                foreach (var propertyToModel in ToModelType.GetProperties())
                {
                    if (propertyFromModel.Name == propertyToModel.Name)
                    {
                        var value = propertyFromModel.GetValue(fromModel);
                        ToModelType.GetProperty(propertyToModel.Name)!.SetValue(dbModel, value);
                    }
                }
            }


            return dbModel;
        }
    }
}
