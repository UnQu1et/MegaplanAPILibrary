using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MegaplanAPILibrary.ApiClasses;
using MegaplanAPILibrary.ApiMethods;

namespace MegaplanAPILibrary
{
    public static class Common
    {
        public static Talk[] GetTalks(string Folder = "incoming", bool FavoritesOnly = false, string DateFrom = "", string DateTo = "", int Limit = 0, string TimeUpdated = "", int Offset = 0)
        {
            var getTalks = new GetTalks
            {
                Request = new GetTalksRequest
                {
                    Pars = new GetTalksRequest.Params
                    {
                        Folder = Folder,
                        FavoritesOnly = FavoritesOnly,
                        DateFrom = DateFrom,
                        DateTo = DateTo,
                        Limit = Limit,
                        TimeUpdated = TimeUpdated,
                        Offset = Offset
                    }
                }
            };
            var response = getTalks.SendRequest();
            if (response.status.code == "ok")
            {
                return response.data.messages;
            }
            else
            {
                throw new Exception("Что-то пошло не так при ответе с сервера: " + response.status.message);
            }
        }
        public static Notification[] GetUnreadNotifications(bool Group = false, string TimeUpdated = "", int Limit = 0, int Offset = 0)
        {
            var getUnreadNotifications = new GetUnreadNotifications
            {
                Request = new GetUnreadNotificationsRequest
                {
                    Pars = new GetUnreadNotificationsRequest.Params
                    {
                        Group = Group,
                        Limit = Limit,
                        TimeUpdated = TimeUpdated,
                        Offset = Offset
                    },
                }
            };
            var response = getUnreadNotifications.SendRequest();
            if (response.status.code == "ok")
            {
                return response.data.notifications;
            }
            else
            {
                throw new Exception("Что-то пошло не так при ответе с сервера: " + response.status.message);
            }
        }
    }
}
