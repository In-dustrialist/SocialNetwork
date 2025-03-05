
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserAddFriendView
    {
        UserService userService;

        public UserAddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(int userId)
        {
            Console.Write("Введите почтовый адрес друга: ");
            string friendEmail = Console.ReadLine();

            try
            {
                userService.AddFriend(userId, friendEmail);
                SuccessMessage.Show("Пользователь успешно добавлен в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким email не найден.");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья.");
            }
        }
    }
}
