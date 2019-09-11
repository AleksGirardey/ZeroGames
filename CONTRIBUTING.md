# Contribution guidelines

## Before Starting, some useful tips for Git :

 Clone the project : `git clone https://github.com/AleksGirardey/ZeroGames.git`

 Obtain status on your branch : `git status`

 Create a branch : `git branch <branch>`
 
 Create a branch and checkout : `git checkout -b <branch>`

 Add files that you changed : `git add <file>`

 Commit your changes : `git commit -m "<comment>"`

 Push your changes : `git push origin <branch>`
 

## Feature branch

 Checkout your project from existing `develop` branch where developments are stable.

    `git fetch development`

    `git checkout -b {BRANCH_NAME}`
	
    `git pull origin develop`

				
### Branch name convention


**1- Working on a feature ??**

In this case an issue number should exist in the Hack'n'Plan project, So typically you should name your branch as follow :

> `ZG-{ISSUE_NUMBER}-{SHORT_DESCRIPTION}`

example : `ZG-8-ajout-ui-course`.


**2- Working on other stuff ?**

If the JIRA issue doesn't exist and/or there is no sense to create it (example: refactor, docs, little feature, crazy experiment, etc ...) You should always create your branch, but *without an issue number*. Just with a significant name.

> Example `Communication-entre-SPA`


## committing work

We have very precise rules over how our git commit messages can be formatted. This leads to more **readable messages** that are easy to follow when looking through the **project history**. But also, we use the git commit messages to generate the **project change log**.


But the real **golden rule** is: 

> **Commit Often, Perfect Later, Publish Once**

**1 Commits should have sens**

If you are committing your work locally multiple times in order to avoid loosing changes. Ensure cleaning you commit history, and perfecting it. You can rebase, filter, squash these unwanted commits away.

here is more details about git [squash](http://gitready.com/advanced/2009/02/10/squashing-commits-with-rebase.html) option.


**2- Commit message format**

Each commit message consists of a **header**, a **body** and a **footer**.

Only the header is mandatory and has a special format that includes a **type**, a **scope** and a **subject**:
    
    <type>(<scope>): <subject>
    
> Important: 
If you have a Jira issue number don't forget to mention it in the commit message, this will enable tracking issues automatically.

Examples:

    docs(changelog): update change log to beta.5
    fix(release): need to depend on latest rxjs and zone.js
    build(docker): add dockerize script to run image on http-server ZG-11

**Type** Must be one of the following:

- **build:** Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
- **ci:** Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
- **docs:** Documentation only changes
- **feat:** A new feature
- **fix:** A bug fix
- **perf:** A code change that improves performance
- **refactor:** A code change that neither fixes a bug nor adds a feature
- **style:** Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- **test:** Adding missing tests or correcting existing tests

**Scope** Could be the feature module name or the component name if it is a shared one

**Subject** should contain the jira issue number if it exist

## Submitting a Pull Request (PR)

Before you submit your Pull Request (PR) consider the following guidelines:

- **Rebase** you feature branch **onto development** branch: `git pull --rebase <remote name> <branch name>`
- **Resolve conflicts** one by one if they exist
- **Push your commit** to a remote feature branch
- **Create a pull/merge request**. here an example in  [Gitlab](https://docs.gitlab.com/ee/gitlab-basics/add-merge-request.html)
- **Assign your merge request to another team member** in order to force **cross validation** and **code review**

## What is next ?

When you finish with the contribution, if you consider working on another feature, you checkout back to develop and create another branch.
Please, consider cleaning your local and remote useless branches when they are merged.

Sometimes, you will need to check if some merge requests need your intervention. You will get the remote branch to merge locally, inspect the changes, verify the code and then accept the Merge Request on GitLab.com.
Maybe, you will need to operate this locally in order to resolve conflicts, be careful and ask your coworker about his code if needed.


## More information

- [Git tutorial (in french)](http://formation.talanlabs.net/git/#1)
- [Working with branches](https://www.atlassian.com/git/tutorials/using-branches)
- [Comparing workflows](https://www.atlassian.com/git/tutorials/comparing-workflows)