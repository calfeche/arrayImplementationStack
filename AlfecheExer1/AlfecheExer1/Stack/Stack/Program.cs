using System;

/// <summary>
/// This application is an implementation of a data structure (Stack) by using a different data strucuture (Array).
/// This allows four functions that particulary captures the behavior of stack which is LIFO (last in, first out).
/// These are: adding values to the stack, removing the topmost values from the stack, printing the last item entered in the stack, and clearing the stack.
/// Made by: Charles Ray A. Alfeche
/// Date: 06 March 2020
/// </summary>

namespace AlfecheExer1_Stacks
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region Initialization of the Notebook
            ///An array is used to output the menu and possible choices of the notebook
            string[] menu = new string[6];
            menu[0] = "Notebook";
            menu[1] = "[1] Add Notebook";
            menu[2] = "[2] Check Notebook";
            menu[3] = "[3] Peek Notebook";
            menu[4] = "[4] Check All";
            menu[5] = "[5] Exit";

            ///A loop is used to iterate the printing of the menu items
            foreach (string i in menu)
            {
                Console.WriteLine(i);
            }

            ///The stack is initialized at the instance of the form with a fixed size of 5
            Stack notebook_stack = new Stack(5);
            ///The menu choice variable is declared which will be reused in the implementation of the action buttons
            int menu_choice; 
            #endregion
            #region Implementation of the Action Buttons

            ///A do-while loop with a nested switch case is used to manipulate the choices.
            ///For future improvement, exception handling and input validation will be added to detect unavailable choices.
            do
            {
                Console.Write("\nSelect an action: ");
                menu_choice = Convert.ToInt32(Console.ReadLine());
                switch (menu_choice)
                {
                    case 1: // The push method is called in this case.
                        Console.Write("Enter the notebook name: ");
                        string item = Console.ReadLine();
                        notebook_stack.Push(item);
                        break;
                    case 2: // The pop method is called in this case.
                        notebook_stack.Pop();
                        break;
                    case 3: // The peek method is called in this case.
                        notebook_stack.Peek();
                        break;
                    case 4: // The check all method is called in this case.
                        notebook_stack.CheckAll();
                        break;

                }
            }
            while (menu_choice != 5 || menu_choice > 5); // This is the exit criteria for the notebook form.
            #endregion
        }
    }

    class Stack
    {
        #region Initialization of the Class: Stack
        /// <summary>
        /// The properties of this on-demand class is defined in this section.
        /// It has the array that will function as a container of the stack, the size property of the stack, and the pointer "top" of the stack.
        /// This also helps instatiate the class when its called across the form.
        /// </summary>
        private int size;
        private string[] array_stack;
        public int top = -1;

        public Stack(int size)
        {
            this.size = size;
            array_stack = new string[size];
        }
        #endregion
        #region Implementation of the Stack Functions
        public void Push(string item)
        {
            if (top > size-1) // Control flow if the number of items pushed exceeds the size of the array
            {
                Console.WriteLine("The Notebook Pile is Full");
            }
            else
            {
                array_stack[++top] = item; // Manipulates the pointer which stands as the index and is increased as newer items are pushed in the stack
            }
        }

       public void Pop()
       {
            if(top == -1)
            {
                Console.WriteLine("The Notebook Pile is Empty"); // Control flow if the array is empty and the prevents removing items
            }
            else
            {
                string value = array_stack[top]; // Calls the topmost item in the array
                Console.WriteLine(value + " has been removed."); // Prints the variable which which reprsents the called item from the previous line
                top--; // Manipulates the pointer to reflect the removal of an item in the array
            }
       }
       
        public void Peek()
        {
            if(top == -1)
            {
                Console.WriteLine("The Notebook Pile is Empty"); // Control flow if the array is empty, returns that there's nothing to view
            }
            else
            {
                string value = array_stack[top]; // Calls the topmost item in the array
                Console.WriteLine(value + " is currently being viewed."); // Prints the variable which which reprsents the called item from the previous line
            }
        }

        public void CheckAll()
        {
            foreach (string i in array_stack)
            {
                Console.WriteLine("You have checked " + i + "'s Notebook."); // Prints all the items inside the array to notify checking
                top--; // Reduces the arrays pointer for item in the array
            }
            
            top = -1; // Resets the pointer to its original state
            Console.WriteLine("The notebook pile is now empty."); // Prints that the array is already empty
        }

        #endregion
    }
}
