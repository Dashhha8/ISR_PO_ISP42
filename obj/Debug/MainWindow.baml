   M S B A M L   `   `   `  ����C  ?avtoServ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:avtoServavtoServ  5   	       avtoServ.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:avtoServ     5   	     � Title$  Автосервис��5   	   $	��500��6   $
��1050��6)   ���	#FF504E76 � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6d   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��390 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ STOAvto��5         AutoGenerateColumns .     
IsReadOnly .    CanUserResizeColumns .  $��0,44,0,0q�6o   ���	#FFC4C3E3   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Номер��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *application_number+6\     5      $	 Дата��6%   $

 auto 6U    63   �� *request_date+6U     5      $	 Клиент��6%   $

 auto 6]    65   �� *Clients.Client_name+6]     5      $	 Автомобиль��6%   $

 auto 6X    69   �� *
Avto.Brand+6X     5      $!	 Серийный номер��6%   $

 auto 6]    6=   �� *Avto.Number+6]     5      $'	 !Тип неисправности��6%   $

 auto 6o    6@   �� *FaultTypes.fault_type_name+6o     5      $	 Деталь��6%   $

 auto 6\    65   �� *Detail.Name_Detail+6\     5      $	 Статус��6%   $

 auto 6c    65   �� *RequestStatus.Status_name+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5      $

 auto 6)      CellTemplate 5      �� 5      .R�5      ��  ��Name$ BtnEdit��6=   -   5        $ ��Редактировать��5   %   6N   5      5      5!      �� 5"   
   -   5        $ BtnAdd_Click_��5"   M   $��Добавить��6   $��1��6$   $
��Left=�62   $	��126��6y   $��	80,10,0,0q�6�   
�������6�   �� 5#   
   -   5        $��BtnAuthorization��5#   M   $��Вернуться��6   $��1��6%   $
��Left=�62   $��
488,10,0,0q�6�   $	��126��6�   ���	#FFF5C74D6�   �� 5$   
   -   5        $��BtnUp��5$   L   $��Обновить��6   $��1��6$   $
��Left=�61   $��
280,10,0,0q�6m   $	��126��6�   ���	#FF8C96576�   �� 5%   
   -   5        $��BtnOut��5%   @   $��Применить��6   $
��Left=�6%   $��	561,8,0,0q�6c   $	��Top=�6v   $��22��6�   $��87��6�    J� RenderTransformOrigin$ 
0.92,0.375&�6�   ��5&      �� 5'       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5(      �  � Color$ 	#FF644E85��6#    � Offset$ 0.009Q�65   � 5)      $ White��6#   $ 0.405Q�61   � 5*      $ 	#FF796C8B��6#   $ 1Q�65   5+      5-      �� 5.   
   -   5        $��BtnDelet��5.   L   $��Удалить��6   $��1��6#   $��Right=�60   $��	0,10,80,0q�6s   $	��126��6�   ���	#FFF1642E6�   �� 5/   
   -   5         ��Name$ ComboStatus��5/   9    �� DisplayMemberPath$ Status_name��6N   $��	428,8,0,0q�6n   $	��Top=�6�   $��21��6�   $
��Left=�6�   $	��118��6�   ���	#FF26262B���	#FF152D3A���	#FF0B0042 �� SelectedItem 6   �� *status_name+6�   �� 50   
   $��Фильтр��6   $
��Left=�6"   $��
361,10,0,0q�6=   $	��Top=�6Q   $��62��6i   
�������$��Italic$�6�   $��14(�6�   �� 51   
   $��
Поиск��6   $��14(�6!   $
��Left=�6/   $��	78,10,0,0q�6J   $	��Top=�6]   $��46��6u   
�������$��Italic$�6�   $ 0.826,0.483&�6�   ��6�   Z� 6�   �� 52   
   $��Выполнено��6   $
��Left=�6%   $��
702,12,0,0q�6@   $	��Top=�6T   $��82��6l   
�������$��Italic$�6�   $��14(�6�   �� 54   
   -	   5         ��Name$	 Box��54      $��20��6   $	��Top=�6+   $��789,10,24,0q�6C    �� 
IsReadOnly . ���	#FFC4C3E36j   �� 55   
   -
   5        $ 	SearchBox��55      $	��200��6%   $��22��61   $��	129,8,0,0q�6a   $	��Top=�6t   $
��Left=�6�   ���	#FFC4C3E36�   56      57      