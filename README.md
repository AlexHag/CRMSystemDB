# User address database - Get the users out entity framework, version

## A. Scenario

> Dude! That web page thing you threw together was great. But I have an idea for a script...

The IT-staff is always fun to interact with. Keeps you on your toe. You get dragged in front of their whiteboard and before long you get the gist of their idea.

> What you're saying is that if you could get users and their addresses out on the command-line I could save you hours each week?

> We're saying exactly that

The entire IT-staff is now around the whiteboard. You respond:

> You know what? Let Lisa, your manager, run through those last disk quota reports while I hack something together.

Game on! They said that using Entity Framework was easy - let's see..

Some days just feels like a deja vu, don't they?

## B. What you will be working on today

Having data in a database is nice, but it's when we get it out and start to display the users to an end-user that it becomes usable to them.

In this exercise we are going to do something dead-simple and just list the users and at the console, to save time for our IT-staff.

We will use Entity Framework for this exercise.

## C. Tools and setup

Use the database from the earlier lab - we have copied the Dockerfile into this repository, and the instructions are the same too;

We have supplied you with a database in a Docker-file. Now, don't worry; we know that you have never used Docker before, but it should be installed on your systems (try to start Docker using Spotlight Search) and you only have to care about two simple commands:

### Starting the database

```bash
docker-compose up -d
```

This will start the database. The first time you run this command it will take about 1-5 minutes. But then it will be lightning fast.

The credentials for the `sa`-account is found in the `docker-compose.yml`-file.

Once the `docker-compose` command has finished you can use Azure Data Studio (should also be installed on your computers) to access the database with those credentials.

### Shutting the database down

Note the `-d` in the command above. This means that the docker container will run in the background. You can see it through the Docker client but other than that it's hidden.

But you want to shut the database down. This can be done through:

```bash
docker stop sql-server-db
```

Note that the database is held in the container so when you shut it down the data is gone.

## D. Lab instructions

The main difference from yesterday is that we're going to list this at the command prompt.

- Create an console application `dotnet new console UserAddressDbEf`
- Read up on how to [parse command line arguments here](https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/march/net-parse-the-command-line-with-system-commandline)
- Create 3 features
  - List all users, without addresses
  - Filter the list of all users by giving the start of the user name, as a parameter
  - List one user, by passing in the id of the user, and show all addresses for that user

Go back to the IT team and demo it. They will ask you to add edit capabilities - if you have time start doing that so that you could change the address.

They will also tell you that you are crazy trying to access the database with raw SQL directly, and ask you to create stored procedures for the use cases above. Update your EF-code to use those stored procedures

---

Good luck and have fun!
