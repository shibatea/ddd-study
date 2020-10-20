using System.Collections.Generic;
using DddStudy.Domain.Interfaces;
using DddStudy.Domain.Models.Users;
using DddStudy.Infra.Contexts;

namespace DddStudy.Infra.Persistence.Users
{
    public class EFUserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public EFUserRepository(MyDbContext context)
        {
            _context = context;
        }

        public User Find(UserId id)
        {
            throw new System.NotImplementedException();
        }

        public User Find(UserName name)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User user)
        {
            // var dataModel = new UserDataModel
            // {
            //     Id = user.Id.Value, // User クラスの Id プロパティが private になるとコンパイルエラー
            //     Name = user.Name.Value
            // };

            // 通知オブジェクトを引き渡しダブルディスパッチにより内部データを取得
            var userDataModelBuilder = new UserDataModelBuilder();
            user.Notify(userDataModelBuilder);

            // 通知された内部データからデータモデルを生成
            var userDataModel = userDataModelBuilder.Build();

            // データモデルをO/Rマッパーに引き渡す
            //_context.Users.Add(userDataModel);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new System.NotImplementedException();
        }

        public List<User> Find(List<UserId> circleMembers)
        {
            throw new System.NotImplementedException();
        }
    }
}