using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MegaplanAPILibrary.ApiClasses
{
    [JsonConverter(typeof(NotificationConverter))]
	public class Notification
	{
		public int Id {get; set;}
        public string Name { get; set; }
		public Subject Subject {get; set;}
		public DateTime TimeCreated {get; set;}
	}
    public class NotificationComment : Notification
    {
        public Content Content { get; set; }
    }
	public class NotificationText : Notification {
		public string Content {get; set;}
	}
	public class Subject 
	{
		public int Id {get; set;}
		public string Name {get; set;}
		public string Type {get; set;}
	}
	public class Content 
	{
		public Subject Subject {get; set;}
		public string Text {get; set;}
		public Author Author {get; set;}
	}
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NotificationConverter : JsonConverter
    {
        public Notification Create(Type objectType, JObject jobject)
        {
            if (jobject["Content"].Type.ToString() == "Object")
            {
                return new NotificationComment();
            }
            else
            {
                return new NotificationText();
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Notification).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            Notification target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
