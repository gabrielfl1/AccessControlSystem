﻿using AccessControl.Server.Models;

namespace AccessControl.Server.ViewModels {
    public class ResultViewModel<T> {
        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();

        public ResultViewModel(T data, List<string> errors) {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data) {
            Data = data;
        }

        public ResultViewModel(List<string> error) {
            Errors = error;
        }

        public ResultViewModel(string error) {
            Errors.Add(error);
        }
    }
}
