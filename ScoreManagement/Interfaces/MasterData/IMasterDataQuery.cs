﻿using ScoreManagement.Model.Table;

namespace ScoreManagement.Interfaces
{
    public interface IMasterDataQuery
    {
        Task<List<SystemParam>> GetSystemParams(string reference);
        Task<Dictionary<string, string>> GetLanguage(string language);
        Task<List<EmailPlaceholder>> GetEmailPlaceholder();
    }
}