# What can I cook?

A website that helps you find recipes based on various criteria, such as the ingredients you have at home, the type of cuisine, the level of difficulty and more. You can also manage the recipes through an admin interface. The website uses React for the frontend, ASP.NET API for the backend and MSSQL for the database.

# How to run the app?

1. Install [Docker](https://www.docker.com/), and run it
2. Clone the projects repository or download it as zip (and extract it)
3. Inside the projects folder rename `.env.template` to `.env` *<sup>1</sup>
4. Open a terminal in the projects folder
5. Tpye `docker compose up -d`
6. Wait until everything finishes
7. [Visit the site](http://localhost:80)

*1: Id'd recommend changing `SA_PASSWORD` and `JWT_TOKEN_KEY` (be careful to meet minimum length)
