﻿using System;
using System.Text;
using Octokit;

namespace Ahk.GitHub.Monitor.Tests.UnitTests.EventHandlersTests
{
    internal static class GitHubMockData
    {
        private const string AhkMonitorYamlEnabledContent = @"enabled: true";

        public static PullRequest CreatePullRequest(int number, ItemState state, int userId)
            => new PullRequest(
                        id: number,
                        nodeId: string.Empty, url: string.Empty, htmlUrl: string.Empty, diffUrl: string.Empty, patchUrl: string.Empty, issueUrl: string.Empty, statusesUrl: string.Empty,
                        number: number, state: state,
                        title: string.Empty, body: string.Empty,
                        createdAt: DateTimeOffset.UtcNow, updatedAt: DateTimeOffset.UtcNow, closedAt: null, mergedAt: null,
                        head: null, @base: null, user: CreateUser(userId), assignee: null, assignees: null,
                        draft: false, mergeable: null, mergeableState: null, mergedBy: null, mergeCommitSha: string.Empty,
                        comments: 0, commits: 0, additions: 0, deletions: 0, changedFiles: 0, milestone: null,
                        locked: false, maintainerCanModify: null, requestedReviewers: null, requestedTeams: null, labels: null);

        public static RepositoryContent CreateRepositoryFileContent(string filePath, string content)
            => new RepositoryContent(
                        name: System.IO.Path.GetFileName(filePath),
                        path: filePath,
                        sha: "dummy", size: 123, type: ContentType.File,
                        downloadUrl: string.Empty, url: string.Empty, gitUrl: string.Empty, htmlUrl: string.Empty, encoding: string.Empty,
                        encodedContent: Convert.ToBase64String(Encoding.UTF8.GetBytes(content)),
                        target: string.Empty, submoduleGitUrl: string.Empty);

        public static RepositoryContent CreateAhkMonitorEnabledYamlFileContent(string content = null)
            => CreateRepositoryFileContent(".github/ahk-monitor.yml", content ?? AhkMonitorYamlEnabledContent);

        public static IssueEvent CreateIssueEvent(EventInfoState @event, int actorId)
            => new IssueEvent(
                        id: 1234, nodeId: string.Empty, url: string.Empty, actor: CreateUser(actorId),
                        assignee: null, label: null, @event: @event,
                        commitId: null, createdAt: DateTimeOffset.UtcNow, issue: null, commitUrl: null, rename: null, projectCard: null);

        public static User CreateUser(int actorId)
            => new User(
                        avatarUrl: string.Empty, bio: string.Empty, blog: string.Empty, collaborators: 0, company: string.Empty,
                        createdAt: DateTimeOffset.UtcNow, updatedAt: DateTimeOffset.UtcNow, diskUsage: 0, email: string.Empty,
                        followers: 0, following: 0, hireable: null, htmlUrl: string.Empty, totalPrivateRepos: 0,
                        id: actorId, location: string.Empty, login: string.Empty, name: string.Empty, nodeId: string.Empty,
                        ownedPrivateRepos: 0, plan: null, privateGists: 0, publicGists: 0, publicRepos: 0, url: string.Empty,
                        permissions: null, siteAdmin: false, ldapDistinguishedName: string.Empty, suspendedAt: null);
    }
}
