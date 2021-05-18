using System;

namespace Banker_Algorism__OS_
{
    class Program
    {
        static void request_function(int[,] need, int[] available_inputs, int[,] alo_inputs, int No_of_process, int No_of_Resources,int No_of_request_process,int[] request_array)
        {
            // bool check=false;

            bool check = false;
            bool[] flags = new bool[No_of_process];
            int[] work = new int[No_of_Resources];
            int[,] temp = new int[No_of_process, No_of_Resources];
            int[] temp2 = new int[No_of_process];
            bool non_safe = true;
            int count = 0;
            int[] order = new int[No_of_process];
            int no_remain_process = No_of_process;

            bool flag = false;
            for(int i=0;i<No_of_Resources;i++)
            {
                if(request_array[i]>need[No_of_request_process,i]&& request_array[i] >available_inputs[i])
                {
                    flag = true;
                }
            }
            if(!flag)
              {
                  for(int j=0;j<No_of_Resources;j++)
                  {
                      need[No_of_request_process, j] = need[No_of_request_process, j] - request_array[j];
                      available_inputs[j] = available_inputs[j] - request_array[j];
                      alo_inputs[No_of_request_process, j] = alo_inputs[No_of_request_process, j] + request_array[j];
                  }
                




                for (int j = 0; j < No_of_Resources; j++)
                {
                    work[j] = available_inputs[j];
                }
                for (int j = 0; j < No_of_process; j++)
                {
                    flags[j] = false;
                }
                while (no_remain_process > 0)
                {
                    non_safe = true;
                    for (int i = 0; i < No_of_process; i++)
                    {
                        for (int j = 0; j < No_of_Resources; j++)
                        {
                            if (need[i, j] > work[j])
                            {
                                temp[i, j] = 1;
                            }
                            temp2[i] = temp2[i] + temp[i, j];
                        }
                        if (flags[i] == false && temp2[i] == 0)
                        {
                            for (int k = 0; k < No_of_Resources; k++)
                            {
                                work[k] = alo_inputs[i, k] + work[k];
                            }
                            flags[i] = true;
                            non_safe = false;
                            no_remain_process--;
                            order[count] = i;
                            count++;
                        }
                        if (i == (No_of_process - 1))
                        {
                            for (int ii = 0; ii < No_of_process; ii++)
                            {
                                temp2[ii] = 0;
                                for (int jj = 0; jj < No_of_Resources; jj++)
                                {
                                    temp[ii, jj] = 0;
                                }
                            }
                        }
                    }
                    if (non_safe)
                        break;
                }
                if (non_safe == true)
                {
                    Console.Write("\n\n");
                    Console.WriteLine("----------------------------------------------");

                    Console.WriteLine("The system is *NON_SAFE*");
                    check = false;
                }
                else
                {
                    Console.Write("\n\n");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("The system is *SAFE*");
                    check = true;
                    Console.WriteLine("The safe sequence is :");
                    Console.Write("<" + " " + "P" + No_of_request_process + "req" + ",");
                    for (int i = 0; i < No_of_process; i++)
                    {
                        Console.Write("p" + order[i]);
                        if (i != No_of_process - 1)
                        {
                            Console.Write("--->");
                        }
                    }
                    Console.Write(" " + ">");
                    Console.Write("\n\n");
                }







            }
            Console.Write("\n\n");
            if (!check || flag)
            {
                Console.WriteLine("This Request is * Not GRANTED *");
            }
            else
            {
                Console.WriteLine("This Request is * GRANTED *");
            }
            Console.Write("\n\n");
            Console.WriteLine("----------------------------------------------");
        }
        static bool safe_state(int[,] need, int[] available_inputs, int[,] alo_inputs, int No_of_process, int No_of_Resources)
        {
            bool check = false;
            bool[] flags = new bool[No_of_process];
            int[] work = new int[No_of_Resources];
            int[,] temp = new int[No_of_process, No_of_Resources];
            int[] temp2 = new int[No_of_process];
            bool non_safe=true ;
            int count = 0;
            int[] order = new int[No_of_process];
            int no_remain_process = No_of_process;
            for (int j = 0; j < No_of_Resources; j++)
            {
                work[j] = available_inputs[j];
            }
            for (int j = 0; j < No_of_process; j++)
            {
                flags[j] = false;
            }
           while(no_remain_process>0)
            {
                non_safe = true;
                for (int i = 0; i < No_of_process; i++)
                {
                    for (int j = 0; j < No_of_Resources; j++)
                    {
                        if (need[i, j] > work[j])
                        {
                            temp[i, j] = 1;
                        }
                        temp2[i] = temp2[i] + temp[i, j];
                    }
                    if (flags[i] == false && temp2[i]==0)
                    {
                        for (int k = 0; k < No_of_Resources; k++)
                        {          
                                work[k] = alo_inputs[i, k] + work[k];
                        }
                        flags[i] = true;
                        non_safe = false;
                        no_remain_process--;
                        order[count] = i;
                        count++;
                    }
                    if (i==(No_of_process-1))
                    {
                        for(int ii=0;ii<No_of_process;ii++)
                        {
                            temp2[ii] = 0;
                            for (int jj = 0; jj < No_of_Resources;jj++)
                            {
                                temp[ii, jj] = 0;
                            }
                        }
                    }
                }
                if (non_safe)
                    break;
            } 
           if(non_safe==true)
            {
                Console.Write("\n\n");
                Console.WriteLine("----------------------------------------------");

                Console.WriteLine("The system is *NON_SAFE*");
                check = false;
            }
            else
            {
                Console.Write("\n\n");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("The system is *SAFE*");
                check = true;
                Console.WriteLine("The safe sequence is :");
                for (int i = 0; i < No_of_process; i++)
                {
                    Console.Write("p" + order[i]);
                    if (i != No_of_process - 1)
                    {
                        Console.Write("--->");
                    }
                }
                Console.Write("\n\n");
            }
            return check;
        }
        static int [,] need_function(int [,] max_inputs, int[,] alo_inputs, int[] available_inputs, int No_of_process, int No_of_Resources)
        {
            int[,] need = new int[No_of_process, No_of_Resources];
            for (int i=0;i<No_of_process;i++)
            {
                for(int j=0;j<No_of_Resources;j++)
                {
                    need[i, j] = max_inputs[i, j] - alo_inputs[i, j];
                }
            }
            return need;
        }
        static int [,] inputs_alo_matrix(int No_of_process, int No_of_Resources)
        {
            int t = 0; // for alo matrix
            int[] seko_2 = new int[100];  //for alo matrix
            int[] array_of_lengths_2 = new int[No_of_process]; // for alo matrix
            string[] input_values_maximum_2 = new string[No_of_process]; // for alo matrix
            int[,] alo_matrix = new int[No_of_process, No_of_Resources]; // for alo matrix
            Console.WriteLine("Please enter the Allocation matrix");
            for (int i = 0; i < No_of_process; i++)
            {
                input_values_maximum_2[i] = Console.ReadLine();
                array_of_lengths_2[i] = input_values_maximum_2[i].Length;
            } // input values for allocate
            for (int k = 0; k < No_of_process; k++)
            {
                for (int i = 0; i < array_of_lengths_2[k]; i++)
                {
                    if (input_values_maximum_2[k][i] == ' ')
                    {
                        seko_2[t] = i;
                        t++;
                    }
                }

                for (int h = 0; h < No_of_process; h++)
                {
                    alo_matrix[h, 0] = Convert.ToInt32(input_values_maximum_2[h].Substring(0, seko_2[0]));
                    for (int i = 1; i < No_of_Resources; i++)
                    {
                        if (i == No_of_Resources - 1)
                        {
                            alo_matrix[h, i] = Convert.ToInt32(input_values_maximum_2[h].Substring(seko_2[i - 1] + 1));
                        }
                        else
                        {
                            alo_matrix[h, i] = Convert.ToInt32(input_values_maximum_2[h].Substring(seko_2[i - 1] + 1, (seko_2[i] - seko_2[i - 1])));

                        }

                    }
                }


            } // splitting string to alocate matrix matrix
            return alo_matrix;
        }
        static int [,] inputs_max_matrix(int No_of_process, int No_of_Resources)
        {
            int j = 0; // for max matrix
            int[] seko = new int[100];  //for max matrix
            int[] array_of_lengths = new int[No_of_process]; // for max matrix
            string[] input_values_maximum = new string[No_of_process]; // for max matrix 
            int[,] max_matrix = new int[No_of_process, No_of_Resources]; // for max matrix
            Console.WriteLine("Please enter the Maximum matrix");
            for(int i=0;i< No_of_process;i++)
            {
                input_values_maximum[i] = Console.ReadLine();
                array_of_lengths[i] = input_values_maximum[i].Length;
            } // input values for maximum
            for(int k=0;k<No_of_process;k++)
            {
                for (int i = 0; i < array_of_lengths[k];i++)
                {
                    if (input_values_maximum[k][i] == ' ')
                    {
                        seko[j] = i;
                        j++;
                    }
                }
                for(int h=0;h<No_of_process;h++)
                {
                    max_matrix[h, 0] = Convert.ToInt32(input_values_maximum[h].Substring(0, seko[0]));
                    for (int i = 1; i < No_of_Resources; i++)
                    {
                        if (i == No_of_Resources - 1)
                        {
                            max_matrix[h, i] = Convert.ToInt32(input_values_maximum[h].Substring(seko[i - 1] + 1));
                        }
                        else
                        {
                            max_matrix[h, i] = Convert.ToInt32(input_values_maximum[h].Substring(seko[i - 1] + 1, (seko[i] - seko[i - 1])));
                        }
                    }
                }
            }  // splitting string to maximum matrix
            return max_matrix;

        }
        static int [] inputs_available_matrix(int No_of_Resources)
        {
            string arrayofnumbers;
            Console.WriteLine("Please enter the available matrix");
            arrayofnumbers = Console.ReadLine();
            int[] sasa = new int[No_of_Resources];
            int j = 0;
            int[] seko = new int[arrayofnumbers.Length];
            for (int i = 0; i < arrayofnumbers.Length; i++)
            {
                if (arrayofnumbers[i] == ' ')
                {
                    seko[j] = i;
                    j++;
                }
            }
            sasa[0] = Convert.ToInt32(arrayofnumbers.Substring(0, seko[0]));
            for (int i = 1; i < No_of_Resources; i++)
            {
                if (i == No_of_Resources - 1)
                {
                    sasa[i] = Convert.ToInt32(arrayofnumbers.Substring(seko[i - 1] + 1));
                }
                else
                {
                    sasa[i] = Convert.ToInt32(arrayofnumbers.Substring(seko[i - 1] + 1, (seko[i] - seko[i - 1])));

                }

            }
            return sasa;

        }
        static int[] inputs_request_matrix(int No_of_Resources)
        {
            string arrayofnumbers;
            Console.WriteLine("Please enter the Request matrix:");
            arrayofnumbers = Console.ReadLine();
            int[] sasa = new int[No_of_Resources];
            int j = 0;
            int[] seko = new int[arrayofnumbers.Length];
            for (int i = 0; i < arrayofnumbers.Length; i++)
            {
                if (arrayofnumbers[i] == ' ')
                {
                    seko[j] = i;
                    j++;
                }
            }
            sasa[0] = Convert.ToInt32(arrayofnumbers.Substring(0, seko[0]));
            for (int i = 1; i < No_of_Resources; i++)
            {
                if (i == No_of_Resources - 1)
                {
                    sasa[i] = Convert.ToInt32(arrayofnumbers.Substring(seko[i - 1] + 1));
                }
                else
                {
                    sasa[i] = Convert.ToInt32(arrayofnumbers.Substring(seko[i - 1] + 1, (seko[i] - seko[i - 1])));

                }

            }
            return sasa;

        }
        static void Main(string[] args)
        {
            while (true)
            {
                int No_of_process = 0;
                int No_of_Resources = 0;
                Console.Write("Please enter the Number of Processes : ");
                string x;
                string y;
                No_of_process = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the Number of Resources : ");
                No_of_Resources = Convert.ToInt32(Console.ReadLine());
                int[,] max_inputs = new int[No_of_process, No_of_Resources];
                int[,] alo_inputs = new int[No_of_process, No_of_Resources];
                int[,] need_outputs = new int[No_of_process, No_of_Resources];
                int[] available_inputs = new int[No_of_Resources];
                int[] request_inputs = new int[No_of_Resources];
                max_inputs = Program.inputs_max_matrix(No_of_process, No_of_Resources);
                alo_inputs = Program.inputs_alo_matrix(No_of_process, No_of_Resources);
                available_inputs = Program.inputs_available_matrix(No_of_Resources);
                need_outputs = Program.need_function(max_inputs, alo_inputs, available_inputs, No_of_process, No_of_Resources);
                int no_process_to_request;
                Console.WriteLine("----------------------------------------------");
                Console.Write("\nThe Need matrix is : \n");
                Console.Write("     ");
                for(int j=0;j<No_of_Resources;j++)
                {
                    Console.Write( "R" + (j+1)+"  ");

                }
                for (int i = 0; i < No_of_process; i++)
                {
                    Console.Write("\n");
                    Console.Write("P" + i);
                    for (int j = 0; j < No_of_Resources; j++)
                        Console.Write("   "+ need_outputs[i, j]);
                }
                Console.Write("\n\n");
                Console.WriteLine("----------------------------------------------");
                Console.Write("\n\n");
                Console.Write("Do you want to know if it is safe  press S , And to request a matrix for a process press R :  ");
                x = Console.ReadLine();
                if (x == "S" || x == "s")

                {
                    Program.safe_state(need_outputs, available_inputs, alo_inputs, No_of_process, No_of_Resources);
                    Console.WriteLine("----------------------------------------------");

                }
               
                else if(x == "R"|| x == "r")
                {
                    Console.Write("Please enter the No. of process  : ");
                    no_process_to_request = Convert.ToInt32(Console.ReadLine());
                    request_inputs = Program.inputs_request_matrix(No_of_Resources); // to send the request array to the function
                    Program.request_function(need_outputs, available_inputs, alo_inputs, No_of_process, No_of_Resources, no_process_to_request, request_inputs);
                }
            }

        }
    }
}
