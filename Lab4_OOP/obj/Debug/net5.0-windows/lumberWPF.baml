   M S B A M L   `   `   `  ����C  ?Lab4_OOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab4_OOPLab4_OOP  5   	       Lab4_OOP.lumberWPF   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab4_OOP     5   	     � Title$  	lumberWPF��5   	   $	��419��6   $	��280��6(   .��5	      � -   5         �Name$ SawingOption_ComboBox��5	      $��	0,0,10,10q�6*   .+�5
   
   �� -   5         ��Name$ 
Wood_Label��5
      $��Древесина��6$   $
��Left=�68   $��	10,10,0,0q�6S   $	��Top=�6f   �� 5   
   -   5         ��Name$ Woods_ComboBox��5      $
��Left=�6+   $��23��6F   $��	10,31,0,0q�6R   $	��Top=�6e   $	��131��6}   �� 5   
   -   5        $ SavingOption_Label��5      $��Метод нарезки��6,   $
��Left=�6D   $��	10,54,0,0q�6_   $	��Top=�6r   �� 5   
   -   5        $ SavingOption_ComboBox��5      $
��Left=�62   $��	10,80,0,0q�6M   $	��Top=�6`   $	��131��6x   $��24��6�   �� 5   
   -   5         ��Name$ EditWood_Button��5      $��Изменить��6*   $
��Left=�6=   $��22��6X   $��
168,14,0,0q�6d   $	��Top=�6x   $��60��6�   6�   �� 5   
   -   5        $ CreateWood_Button��5      $��Создать��6,   $
��Left=�6>   $��22��6Y   $��
169,45,0,0q�6e   $	��Top=�6y   $��59��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ Date_DatePicker��5      $
��Left=�6.   $��
15,118,0,0q�6I   $	��Top=�6]   $	��179��6u      FirstDayOfWeek$ Monday=�6�      IsTodayHighlighted$
 True��6�   �� 5   
   $��Маркировка��6   $
��Left=�6%   $��
15,159,0,0q�6@   $	��Top=�6T   �� 5   
   $��Количество��6   $
��Left=�6%   $��
15,200,0,0q�6@   $	��Top=�6T   �� 5   
   $��Цена��6   $
��Left=�6   $��
24,241,0,0q�6:   $	��Top=�6N   �� 5   
   -	   5         ��Name$ Marking_TextBox��5      $
��Left=�6+   $��
94,163,0,0q�6F   	 �� TextWrapping$
	 Wrap=�6Z   $	��Top=�6n   $	��120��6�   �� 5   
   -
   5        $ Quantity_TextBox��5      $
��Left=�6,   $��
94,204,0,0q�6G   $
	 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   -   5        $ Price_TextBox��5      $
��Left=�6)   $��
94,245,0,0q�6D   $
	 Wrap=�6X   $	��Top=�6l   $	��120��6�   �� 5   
   -   5        $ Save_Button��5      $��Сохранить��6&   $��Center=�6:   $��	0,288,0,0q�6W   $	��Top=�6j   $��64��6�   6�   �� 5   
   -   5        $ Cancel_Button��5      $��Отмена��6(   $��Center=�69   $��	0,321,0,0q�6V   $	��Top=�6i   $��22��6�   $��63��6�   5      5      