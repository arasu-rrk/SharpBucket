﻿using NServiceKit.ServiceHost;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpBucket.Authentication{
    public class OAuthentication2Legged : OauthAuthentication, IAuthenticate{
        private readonly RestClient client;

        public OAuthentication2Legged(string consumerKey, string consumerSecret) : base(consumerKey, consumerSecret){
            client = new RestClient(baseUrl){
                Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, ConsumerSecret, null, null)
            };
        }

        public string GetResponse<T>(string url, string method, IReturn<T> body){
            return RequestExcecutor.ExectueRequest(url, method, body, client);
        }
    }
}