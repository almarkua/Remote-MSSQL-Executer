   M S B A M L   `   `   `  ����   Remote MSSQL Executer    lab4_1_PRBD.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Queries��$	��482��$	��618��.��� .+��� $��Query:��$
��Left=�$��	10,10,0,0q�$	��Top=��� -    ��Name$ QueryTextBox��$��26��$��
60,10,95,0q� �� TextWrapping$
 Wrap=�$	��Top=����� *Query+�� $�� ��$
��Left=�$��	17,41,0,0q�$	��Top=��� -    ��Name$ ExecuteButton��$��Execute��$��	0,10,10,0q�$	��Top=�$��26��$��Right=�$��75������ *ExecuteButtonClickCommand+�� $��Result��$��10,41,209,10q�.��&   System.Windows.Controls.DataGrid  -     Name$ ResultDataGrid��$��0,0,-2,0q�   AutoGenerateColumns . ���� *ResultTable+ �� Mode$ TwoWay=��� $��
Parameters��$��
0,41,10,10q�$��Right=�$	��194��.��  -   $ ParabetersDataGrid�� J� RenderTransformOrigin$ -3.667,-2.154&�$��0,0,-2,0q� .    CanUserAddRows . 	   
IsReadOnly	 .  ���� *
Parameters+