using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp3HttpListener
{
	class Program
	{
		static void Main(string[] args)
		{
			//         HttpListener listener = new HttpListener();
			//         // установка адресов прослушки
			//         listener.Prefixes.Add("http://localhost:8888/connection/");
			//         listener.Start();
			//         Console.WriteLine("Ожидание подключений...");
			//         // метод GetContext блокирует текущий поток, ожидая получение запроса 
			//         HttpListenerContext context = listener.GetContext();
			//         HttpListenerRequest request = context.Request;
			//         // получаем объект ответа
			//         HttpListenerResponse response = context.Response;
			//         // создаем ответ в виде кода html
			//         string responseStr = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
			//         byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
			//         // получаем поток ответа и пишем в него ответ
			//         response.ContentLength64 = buffer.Length;
			//         Stream output = response.OutputStream;
			//         output.Write(buffer, 0, buffer.Length);
			//         // закрываем поток
			//         output.Close();
			//         // останавливаем прослушивание подключений
			//         listener.Stop();
			//         Console.WriteLine("Обработка подключений завершена");
			//Console.WriteLine($"Получен {request.RawUrl}");
			//         Console.Read();

			var t = Listen();

			t.Wait();

			//Console.Read();
        }

        private static async Task Listen()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.5:5001/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

			while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

				var now = DateTime.Now;

                string responseString = $"<html><head><meta charset='utf8'></head><body>Привет мир! Сейчас {now.ToLongTimeString()}</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();

				Console.WriteLine($"Получен {request.RawUrl}");
			}
        }
    }
}
