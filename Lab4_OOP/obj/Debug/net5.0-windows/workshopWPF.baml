   M S B A M L   `   `   `  ����C  ?Lab4_OOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Lab4_OOPLab4_OOP  5   	       Lab4_OOP.workshopWPF   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Lab4_OOP     5   	     � Title$  workshopWPF��5   	   $	��340��6   $	��434��6*   .��5	      � $��	0,0,10,-6q�6    � ColumnDefinitions 5
   
   �� 5      $
��343* �6   �� 5      $	��81* �6   .+�5   
   �� $+��%Количество объектов��6   $
��Left=�6.   $��24��6I   $��	26,29,0,0q�6U   $	��Top=�6h   $	��131��6�   �� 5   
   -   5         ��Name$ Lumber_List��5      $��26,104,10,10q�6'   �� 5   
   -   5         ��Name$ CountObject_Label��5      $��Label��6+   $
��Left=�6;   $��
162,28,0,0q�6V   $	��Top=�6j    J� RenderTransformOrigin$ -0.329,0.271&�6�   $��72��6�   $��26��6�   �� 5   
   $#��Общая стоимость��6   $
��Left=�6*   $��	26,53,0,0q�6E   $	��Top=�6X   $��91��6p   $��26��6{   �� 5   
   -   5        $ TotalPrice_Label��5      $��Label��6*   $
��Left=�6:   $��32��6U   $��
162,53,0,0q�6a   $	��Top=�6u   $��95��6�   $ 0.237,-0.171&�6�   �� 5   
   -   5         ��Name$ Create_Button��5      $��Создать��6(   $��Center=�6:   $��	0,104,0,0q�6W   $	��Top=�6j   $ -0.044,-0.431&�6�   $��25��6�   $��56��6�   $��1��6�   �� 5   
   -   5        $ Edit_Button��5      $��Изменить��6&   $��Center=�69   $��24��6V   $��	0,141,0,0q�6b   $	��Top=�6u   $��58��6�   $��1��6�   �� 5   
   -   5        $ SaveandExit_Button��5      $)��#Выйти сохранившись��6-   $
��Left=�6J   $��32��6e   $��
280,21,0,0q�6q   $	��Top=�6�   $	��132��6�   $��2��6�    J� 	AllowDrop$
 True��6�   �� 5   
   -   5        $ Cancel_Button��5      $��Отмена��6(   $��Center=�69   $��	0,187,0,0q�6V   $	��Top=�6i   $��25��6�   $��55��6�   $��1��6�    �� IsCancel$
 True��6�   5      5      