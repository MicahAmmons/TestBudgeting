This passion project was conceived as a means of bringing organization and order to my life, and anyone who uses it. Customized to fit my needs and flexible enough to accommodate the needs of anyone, this application utilizes the following technologies:

- MySQL Workbench (for local storage)
- OpenWeather API
- Gmail API
- ASP.NET Model-View-Controller (MVC) pattern
- All together, you'll get a snapshot of your day, your budgetary progress, any specific expenses, daily/weekly reminders, daily weather forecasts, and even your unread emails. Below are details of each view, how it functions, and what to expect:

View: Home (Dashboard)
- The Home view serves as a dashboard providing snapshots of customized views. Here's what you'll find:
   - Weather: There are two prearranged weather segments that display the daily weather for McKinney and Hoboken, pulled using the OpenWeatherMap API. The layout is designed as I wanted but can be customized as needed.
   - Reminders: Reminders are instanced objects with properties such as Details, Date, and Weekly Days (for recurring reminders). Currently, this is connected to a local SQL database but can easily be connected to any database by editing the connection settings. Reminders will stay displayed starting on the day they are set to occur and won't disappear until the Completion checkbox is toggled. To add a new reminder, simply type the optional details in the form just under the Reminder table, click the "+" icon, and your reminder will be added.
   - Budgets: Your preselected budget will be displayed as a progress bar here. To add or change budgets, simply visit the Budget View page (details below).
   - Expenses: As of now, there is no connection to accounts or banks, so expenses will be added manually. On the Home page, there is an "Add Expense" button, or you can visit the Expenses View page.
   - Gmail (In Progress): You will find an authentication button that, once clicked, has you sign into your Gmail account. Once authenticated, a list of your most recent unread emails will appear at the bottom of the page. From here, you can see the sender, subject, date, and content of the email. In the future, there will be an option to mark as read and even respond.

View: Expenses
I've always struggled to find budgeting apps that worked for me and didn't cost an arm and a leg. That's why I decided to create a customized expense tracker. Here's what you can expect:
   - All expenses have to be entered manually and are stored in a local SQL database (can be integrated into a new database as needed).
   - Expenses are objects with properties such as Amount, Budget, Payee, and Date.
   - The Expenses View will show a table of all your expenses, where you can use JavaScript to sort by column value or even hide columns you don't want to see.
   - Want to add an Expense? Simply click the "Add Expense" button to be brought to a form page to insert new expenses into the database.
   - Want to update or delete an expense? Simply click the corresponding ID of the expense you want to edit and go from there!

View: Budgets
I've always struggled to keep to a budget. If I can't see it every day, then I forget it exists, or I'm less likely to follow it. Here's what the Budgets page offers:
   - The budgets page allows you to create custom budgets, set their amount, and edit them at any time.
   - When expenses are created, they have to be assigned to one of these budgets from a dropdown menu.
   - The budgets view shows a progress bar for each budget. It displays your set budget amount as well as the total of all expenses within that budget for the month.
   - Budgets are fully customizable, so you'll never lose track of where you are again!
