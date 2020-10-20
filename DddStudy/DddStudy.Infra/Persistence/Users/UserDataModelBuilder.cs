using DddStudy.Domain.Models.Users;
using DddStudy.Infra.Persistence.DataModels;

namespace DddStudy.Infra.Persistence.Users
{
    public class UserDataModelBuilder : IUserNotification
    {
        // 通知されたデータはインスタンス変数で保持される
        private UserId _id;
        private UserName _name;

        public void Id(UserId id)
        {
            _id = id;
        }

        public void Name(UserName name)
        {
            _name = name;
        }

        // 通知されたデータからデータモデルを生成するメソッド
        public UserDataModel Build()
        {
            return new UserDataModel
            {
                Id = _id.Value,
                Name = _name.Value
            };
        }
    }
}