﻿using JobApplication.Models;
using JobApplication.Services;

namespace JobApplication;

public class ApplicationEvaluator
{
    private const int minAge = 18;
    private const int autoAcceptedYearOfExperience = 15;

    private List<string> techStackList =
    [
        "C#",
        "RabbitMQ",
        "MicroService",
        "VisualStudio",
    ];

    private IdentityValidator identityValidator;

    public ApplicationEvaluator()
    {
        identityValidator = new IdentityValidator();
    }

    public ApplicationResult Evaluate(JobApplicationModel form)
    {
        if (form.Applicant.Age < minAge)
        {
            return ApplicationResult.AutoRejected;
        }

        var validIdentity = identityValidator.IsValid(form.Applicant.IdentityNumber);

        if (!validIdentity) return ApplicationResult.TransferredToHR;

        var sr = GetTechStackSimilarityRate(form.TechStackList);

        if (sr < 25)
        {
            return ApplicationResult.AutoRejected;
        }

        if (sr > 75 && form.YearsOfExperience > autoAcceptedYearOfExperience)
        {
            return ApplicationResult.AutoAccepted;
        }

        return ApplicationResult.AutoAccepted;
    }

    private int GetTechStackSimilarityRate(List<string> techStacks)
    {
        int matchedCount = techStackList.Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase)).Count();
        return (int)((double)matchedCount / techStackList.Count) * 100;

    }



}


public enum ApplicationResult
{
    AutoRejected,
    TransferredToHR,
    TransferredToLead,
    TransferredToCTO,
    AutoAccepted
}