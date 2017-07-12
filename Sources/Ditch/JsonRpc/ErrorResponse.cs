using System;
using Newtonsoft.Json;

namespace Ditch.JsonRpc {
   [JsonObject(MemberSerialization.OptIn)]
   public class ErrorResponse {
      [JsonProperty("code")]
      public long Code { get; set; }

      [JsonProperty("message")]
      public string Message { get; set; }

      [JsonProperty("data")]
      public ErrorData Data { get; set; }

      public ErrorResponse() {
      }

      public ErrorResponse(string message) {
         Message = message;
      }
   }

   [JsonObject(MemberSerialization.OptIn)]
   public class ErrorData {
      [JsonProperty("code")]
      public long Code { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("message")]
      public string Message { get; set; }

      [JsonProperty("stack")]
      public ErrorDataStack[] Stack { get; set; }
   }

   public class ErrorDataStack {
      [JsonProperty("context")]
      public ErrorDataStackContext Context { get; set; }

      [JsonProperty("format")]
      public string Format { get; set; }

      [JsonProperty("data")]
      public object Data { get; set; }
   }

   public class ErrorDataStackContext {
      [JsonProperty("level")]
      public string Level { get; set; }

      [JsonProperty("file")]
      public string File { get; set; }

      [JsonProperty("line")]
      public long Line { get; set; }

      [JsonProperty("method")]
      public string Method { get; set; }

      [JsonProperty("hostname")]
      public string HostName { get; set; }

      [JsonProperty("thread_name")]
      public string ThreadName { get; set; }

      [JsonProperty("timestamp")]
      public DateTime TimeStamp { get; set; }
   }
}