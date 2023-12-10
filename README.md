This passion project was conceieved as a means of bringing orgnaization and order to my (and anyone who uses it) life.
Customized to fit my needs and flexible to add the needs of anyone, this application utilizes:
- MySQL WorkBench (for local storage) 
- OpenWeather API
- Gmail API
- ASP.NET Model, View, Controller pattern
All together, you'll get a snapshot of your day, your budgetary progress, any specific expenses, daily/weekly reminders, daily weather forecast, and even your unread emails. 
Details of each view, how it functions, and what to expect below


(View) Home -> Dashboard
The Home view works as a dashboard providing snapshots of customized views. 
   - You'll find 2 prearranged Wether segments that display the daily weather for McKinney and Hoboken.  These are pulled utilizing the OpenWeatherMap API,
and the layout is designed as I wanted, but can be customized as anyone sees fit. 
   - Reminders will be found here as well.  Reminders are an instanced object with Properties such as: Details, Date, Weekly Days (reoccuring reminders).  As of now, 
this is connected to a local SQL database but can easily be reconnected to any, simply edit the connections settings as needed.  Reminders will stay displayed starting the
day they are set to do, and won't disappear until the Completion checkbox is toggled.  To add a new reminder, simply type the optional details in the form just under the
Reminder table, click the "+" icon, and your reminder will be added in!
   - Budgets - Your preselected budget will be displayed as a progress bar here.  To add or change budgets, simply visit the Budget View page (details below).
   - Expenses - as of now there is no connection to accounts or banks, so expenses will be added in manually.  On the Home page, there is an "Add Expense" button or simply
visit the Expenses View page. 
   - Gmail (In progress): You will find an authentication button that, once clicked, has you sign into your Gmail account.  Once authenticated, a list of your most recent
unread emails will appear at the bottom of the page.  From here, you can see the sender, subject, date, and content of the email.  In the future, there will be an
option to mark as read and to even respond.    

(View) Expenses
I've always struggled to find budgeting apps that worked for me and didn't cost an arm and a leg.  That is why I decided to make a customized expense tracker
   - All expenses have to be put in manually and are stored in a local SQL datashbase (can be integrated into a new database as needed). 
   - Expenses are objects with properties of: Amount, Budget, Payee, and Date.
   - The Expenses View will show a table of all your expenses, where, use Java Scripts, you can sort by column value, or even hide columns you don't want to see.
   - Want to add an Expense?  Simply click the Add Expense button to brought to a form page to insert new Expenses into the database. 
   - Want to update or delete an expense?  Simply click the coresponding ID of the expense you want to edit, and go from there!

(view) Budgets
I've always struggled to keep to a budget.  If I can't see it every day, then I forget it exists or I'm less likely to follow it
   - The budgets page allows you to create custom budgets, set their amount, and even edit them at anytime.
   - When expenses are created, they have to be assigned to one of these budgets from a dropdown menu.
   - The budgets view shows a progress bar of each budget.  It displays your set budget amount as well as the total of all expenses within that budget for the month.
   - Budgets are fully customizable - never lose track of where you are again! 






# TestBudgeting
